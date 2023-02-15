using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestQuestionService _testQuestionService;
        private readonly ITestService _testService;
        private readonly IResultService _resultService;
        private readonly IQuestionService _questionService;
        private readonly IResultAnswerService _resultAnswerService;

        private const string questionNumberKey = "questionNumber";
        private const int firstQuestionNumber = 0;
        public TestController(ITestQuestionService testQuestionService, ITestService testService,
            IResultService resultService, IQuestionService questionService, IResultAnswerService resultAnswerService)
        {
            _testQuestionService = testQuestionService;
            _testService = testService;
            _resultService = resultService;
            _questionService = questionService;
            _resultAnswerService = resultAnswerService;
        }

        public async Task<IActionResult> Index()
        {
            var tests = await _testService.GetAllAsync();

            return View(tests);
        }

        [Route("StartTest/{id}")]
        public async Task<IActionResult> EnterUserName(int id)
        {
            TempData.Clear();
            var test = await _testService.GetByIdAsync(id);
            if (test.IsPublished)
            {
                return View(test);
            }
            return RedirectToAction("Index", "Home");
        }

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
            return RedirectToAction(nameof(Question), new { resultId = emptyUserResult.Id });
        }

        [Route("[controller]/{resultId:int}")]
        public async Task<IActionResult> Question(int resultId)
        {
            var result = await _resultService.GetByIdAsync(resultId);
            var testQuestions = await _testQuestionService.GetAllByTestIdIncludeQuestionAndAnswersWithoutIsCorrectAsync(result.TestId);

            TempData[questionNumberKey] = firstQuestionNumber;
            ViewBag.testId = result.TestId;
            ViewBag.resultId = result.Id;
            ViewBag.endedAt = result.StartedAt.AddSeconds(Mapper.FromMinutesToSeconds(testQuestions.First().Test.TestDuration)).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            return View(testQuestions[firstQuestionNumber].Question);
        }

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
                return RedirectToAction(nameof(Result), new { resultId = UserAnswerModel.ResultId });
            }

            return PartialView("QuestionPartial", testQuestions[questionNumber].Question);
        }


        [HttpGet]
        public async Task<IActionResult> Result(int resultId, bool isExpired)
        {
            ViewBag.ResultId = resultId;
            ViewBag.IsExpired = isExpired ? 1 : 0;

            ResultModel result = await _resultService.GetByIdAndCalculateAsync(resultId);

            ViewBag.TestData = await _testService.GetByIdAsync(result.TestId);

            return View("Result", result);
        }
    }
}
