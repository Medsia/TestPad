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
        public async Task<IActionResult> CreatePreliminaryUserResultForTest(ResultModel resultModel)
        {
            var emptyUserResult = await _resultService.CreateAsync(new ResultModel
            {
                TestId = resultModel.TestId,
                UserName = resultModel.UserName,
                UserSurname = resultModel.UserSurname,
                Score = -1,
                StartedAt = DateTime.Now.ToUniversalTime(),
                FinishedAt = DateTime.MinValue
            });

            return RedirectToAction(nameof(Question), new UserTestQuestion { ResultId = emptyUserResult.Id });
        }

        public async Task<IActionResult> Question(UserTestQuestion userTestQuestion)
        {
            var result = await _resultService.GetByIdAsync(userTestQuestion.ResultId);
            var testQuestions = await _testQuestionService.GetAllByTestIdAsync(result.TestId);

            if (userTestQuestion.QuestionNumber >= testQuestions.Count)
                return RedirectToAction(nameof(Result), new { resultId = result.Id });

            var question = await _questionService.
                GetByIdIcludingAnswersWithoutIsCorrectAsync(testQuestions[userTestQuestion.QuestionNumber].QuestionId);
            var test = await _testService.GetByIdAsync(result.TestId);
            
            ViewBag.resultId = result.Id;
            ViewBag.questionNumber = userTestQuestion.QuestionNumber;
            ViewBag.endedAt = result.StartedAt.AddSeconds(test.TestDuration).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendUserAnswer(UserAnswerModel UserAnswerModel)
        {
            await _resultAnswerService.AddUserResultAnswersAsync(UserAnswerModel.ResultId,
                UserAnswerModel.AnswersIds);
            return RedirectToAction(nameof(Question), new UserTestQuestion
            {
                ResultId = UserAnswerModel.ResultId,
                QuestionNumber = UserAnswerModel.QuestionNumber + 1
            });
        }


        [HttpGet]
        public async Task<IActionResult> Result(int resultId, bool isExpired)
        {
            ViewBag.ResultId = resultId;
            ViewBag.IsExpired = isExpired ? 1: 0;

            var result = await _resultService.GetByIdAsync(resultId);
            if (result.Score < 0)
            {
                result.Score = await _resultService.CalculateScore(resultId);
                result.FinishedAt = await _resultService.CalculateFinishTime(resultId);
            }

            ViewBag.TestData = await _testService.GetByIdAsync(result.TestId);

            return View("Result", result);
        }
    }
}
