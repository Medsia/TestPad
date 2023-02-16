using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace LX.TestPad.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly ITestQuestionService _testQuestionService;
        private readonly ITestService _testService;
        private readonly IResultService _resultService;
        private readonly IQuestionService _questionService;
        private readonly IResultAnswerService _resultAnswerService;
        private readonly IEncoder _encoder;

        private const string questionNumberKey = "questionNumber";
        private const int firstQuestionNumber = 0;
        public TestController(ITestQuestionService testQuestionService, ITestService testService,
            IResultService resultService, IQuestionService questionService,
            IResultAnswerService resultAnswerService, IEncoder encoder)
        {
            _testQuestionService = testQuestionService;
            _testService = testService;
            _resultService = resultService;
            _questionService = questionService;
            _resultAnswerService = resultAnswerService;
            _encoder = encoder;
        }

        public async Task<IActionResult> Index()
        {
            var tests = await _testService.GetAllAsync();

            return View(tests);
        }

        [Route("{id}")]
        public async Task<IActionResult> StartTest(int id)
        {
            TempData.Clear();
            var test = await _testService.GetByIdAsync(id);
            if (test.IsPublished)
            {
                string encodedTestId = _encoder.Encode(test.Id.ToString());
                TempData["TestId"] = encodedTestId;
                return RedirectToAction(nameof(EnterUserName), new { testId = encodedTestId });
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("Start/{testId}")]
        public async Task<IActionResult> EnterUserName(string testId)
        {
            var decodedTestId = _encoder.Decode(testId);
            var test = await _testService.GetByIdAsync(int.Parse(decodedTestId));
            if (test != null && test.IsPublished)
            {
                // Check that the test ID in the URL matches the one stored in TempData
                if (TempData["TestId"]?.ToString() != testId)
                {
                    return RedirectToAction(nameof(StartTest), new { id = test.Id });
                }
                return View(test);
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("CreateResult")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePreliminaryUserResultForTest(ResultModel resultModel)
        {
            var emptyUserResult = await _resultService.CreateAsync(new ResultModel
            {
                TestId = resultModel.TestId,
                UserName = resultModel.UserName,
                UserSurname = resultModel.UserSurname,
                Score = 0,
                IsCalculated = false,
                StartedAt = DateTime.Now.ToUniversalTime(),
                FinishedAt = DateTime.MinValue
            });
            return RedirectToAction(nameof(Question), new { resultId = _encoder.Encode(emptyUserResult.Id.ToString()) });
        }

        [Route("Questions/{resultId}")]
        public async Task<IActionResult> Question(string resultId)
        {
            if (!TempData.ContainsKey(questionNumberKey))
            {
                RedirectToAction(nameof(Index));
            }
            var result = await _resultService.GetByIdAsync(int.Parse(_encoder.Decode(resultId)));
            var testQuestions = await _testQuestionService.GetAllByTestIdIncludeQuestionAndAnswersWithoutIsCorrectAsync(result.TestId);

            TempData[questionNumberKey] = firstQuestionNumber;
            ViewBag.resultIdEncoded = resultId;
            ViewBag.resultId = result.Id;
            ViewBag.testId = result.TestId;
            ViewBag.questionNumber = firstQuestionNumber;
            ViewBag.questionCount = testQuestions.Count;
            ViewBag.endedAt = result.StartedAt.AddSeconds(Mapper.FromMinutesToSeconds(testQuestions.First().Test.TestDuration)).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            return View(testQuestions[firstQuestionNumber].Question);
        }

        [Route("SendUserAnswer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendUserAnswer(UserAnswerModel UserAnswerModel)
        {
            if (!TempData.ContainsKey(questionNumberKey))
            {
                RedirectToAction(nameof(Index));
            }

            int questionNumber = (int)TempData[questionNumberKey];
            TempData[questionNumberKey] = ++questionNumber;

            await _resultAnswerService.AddUserResultAnswersAsync(UserAnswerModel.ResultId,
                UserAnswerModel.AnswersIds);

            var testQuestions = await _testQuestionService.GetAllByTestIdIncludeQuestionAndAnswersWithoutIsCorrectAsync(UserAnswerModel.TestId);
            if (questionNumber >= testQuestions.Count)
            {
                return PartialView("PreResultPartial", _encoder.Encode(UserAnswerModel.ResultId.ToString()));
            }

            return PartialView("QuestionPartial", testQuestions[questionNumber].Question);
        }

        [Route("Result/{resultId}&{isExpired}")]
        [HttpGet]
        public async Task<IActionResult> Result(string resultId, bool isExpired)
        {
            var resultIdDecoded = int.Parse(_encoder.Decode(resultId));
            ViewBag.ResultId = resultIdDecoded;
            ViewBag.IsExpired = isExpired ? 1 : 0;

            ResultModel result = await _resultService.GetByIdAndCalculateAsync(resultIdDecoded);

            ViewBag.TestData = await _testService.GetByIdAsync(result.TestId);

            return View("Result", result);
        }
    }
}
