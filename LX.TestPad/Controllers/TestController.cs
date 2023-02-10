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

        public async Task<IActionResult> EnterUserName(int id)
        {
            var test = await _testService.GetByIdAsync(id);

            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePreliminaryUserResultForTest(TestModel testModel)
        {
            var resultModel = await _resultService.CreateAsync(new ResultModel
            {
                TestId = testModel.Id,
                UserName = testModel.UserName + testModel.UserSurname,
                Score = 0,
                StartedAt = DateTime.Now.ToUniversalTime(),
                FinishedAt = DateTime.MinValue
            });

            return RedirectToAction(nameof(Question), new { @resultId = resultModel.Id });
        }

        public async Task<IActionResult> Question(int resultId, int questionNumber)
        {
            var result = await _resultService.GetByIdAsync(resultId);
            var testQuestions = await _testQuestionService.GetAllByTestIdAsync(result.TestId);
            if (questionNumber >= testQuestions.Count)
                return RedirectToAction(nameof(Result));
            var question = await _questionService.GetByIdIcludingAnswersAsync(testQuestions[questionNumber].QuestionId);
            var test = await _testService.GetByIdAsync(result.TestId);

            ViewBag.resultId = resultId;
            ViewBag.questionNumber = questionNumber;
            ViewBag.endedAt = result.StartedAt.AddSeconds(test.TestDuration).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendUserAnswer(int resultId,
            int[] answersIds, int questionNumber)
        {
            await _resultAnswerService.AddUserResultAnswersAsync(resultId, answersIds);

            return RedirectToAction(nameof(Question), new { @resultId = resultId, @questionNumber = questionNumber + 1 });
        }

        [Route("Result")]
        public IActionResult Result()
        {
            return View();
        }
    }
}
