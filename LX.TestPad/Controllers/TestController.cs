using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
        public TestController(ITestQuestionService testQuestionService, ITestService testService,
            IResultService resultService, IQuestionService questionService, IResultAnswerService resultAnswerService)
        {
            _testQuestionService = testQuestionService;
            _testService = testService;
            _resultService = resultService;
            _questionService = questionService;
            _resultAnswerService = resultAnswerService;
        }

        public IActionResult Index()
        {
            var tests = _testService.GetAllAsync();

            return View(tests);
        }

        [Route("StartTest/{id}")]
        public async Task<IActionResult> EnterUserName(int id)
        {
            TempData.Clear();
            var test = await _testService.GetByIdAsync(id);

            return View(test);
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
            TempData[questionNumberKey] = 0;
            return RedirectToAction(nameof(Question), new { resultId = emptyUserResult.Id });
        }

        [Route("{resultId}")]
        public async Task<IActionResult> Question(int resultId)
        {
            if (!TempData.ContainsKey(questionNumberKey))
            {
                RedirectToAction(nameof(Index));
            }
            var result = await _resultService.GetByIdAsync(resultId);
            var testQuestions = await _testQuestionService.GetAllByTestIdIncludeQuestionAndAnswersWithoutIsCorrectAsync(result.TestId);
            int questionNumber = (int)TempData[questionNumberKey];

            if (questionNumber >= testQuestions.Count)
            {
                TempData.Clear();
                return RedirectToAction(nameof(Result), new { resultId = result.Id });
            }

            TempData[questionNumberKey] = questionNumber;
            
            ViewBag.resultId = result.Id;
            ViewBag.endedAt = result.StartedAt.AddSeconds(testQuestions.First().Test.TestDuration).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            return View(testQuestions[questionNumber].Question);
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

            return RedirectToAction(nameof(Question), new { resultId = UserAnswerModel.ResultId });
        }


        [HttpGet]
        public async Task<IActionResult> Result(int resultId, bool isExpired)
        {
            ViewBag.ResultId = resultId;
            ViewBag.IsExpired = isExpired ? 1: 0;

            var result = await _resultService.GetByIdAndCalculateAsync(resultId);

            ViewBag.TestData = await _testService.GetByIdAsync(result.TestId);

            return View("Result", result);
        }
    }
}
