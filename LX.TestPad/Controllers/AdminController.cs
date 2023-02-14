using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.Authorization;
using LX.TestPad.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
    public class AdminController : Controller
    {
        private readonly ITestQuestionService _testQuestionService;
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly IResultService _resultService;
        public AdminController(ITestQuestionService testQuestionService, ITestService testService,
            IQuestionService questionService, IAnswerService answerService, IResultService resultService)
        {
            _testQuestionService = testQuestionService;
            _testService = testService;
            _questionService = questionService;
            _answerService = answerService;
            _resultService = resultService;
        }

        public async Task<IActionResult> Index()
        {
            var tests = await _testService.GetAllAsync();

            return View(tests);
        }
        public IActionResult ExistingQuestions(int testId)
        {
            return View(testId);
        }

        public async Task<IActionResult> TestResults()
        {
            var results = await _resultService.GetAllIncludeTestAsync();
            return View(results);
        }

        public IActionResult ShowTest()
        {
            return View();
        }

        public IActionResult ResultDetails()
        {
            return View();
        }

        public IActionResult CreateTest()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTest(TestModel testModel)
        {
            var test = await _testService.CreateAsync(testModel);
            return RedirectToAction(nameof(TestDetails), new { id = test.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTest(TestModel test)
        {
            await _testService.UpdateAsync(test);
            return RedirectToAction(nameof(TestDetails), new { id = @test.Id }); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeIsPublishedTest(TestModel test)
        {
            test.IsPublished = !test.IsPublished;
            await _testService.UpdateAsync(test);
            return RedirectToAction(nameof(TestDetails), new { id = @test.Id });
        }

        public async Task<IActionResult> TestQuestions(int testId)

        {
            var testQuestions = await _testQuestionService.GetAllByTestIdIncludeQuestionsWithAnswersAsync(testId);
            ViewBag.TestId = testId;
            return View(testQuestions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQuestion(QuestionModel question)
        {
            await _questionService.UpdateAsync(question);
            return RedirectToAction(nameof(TestQuestions), new { testId = question.TestId }); ;
        }

        public IActionResult CreateQuestion(int testId)
        {
            return View(new QuestionModel { TestId = testId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuestion(QuestionModel questionModel)
        {
            var question = await _questionService.CreateAsync(questionModel);
            await _testQuestionService.CreateAsync(question.Id, questionModel.TestId);

            return RedirectToAction(nameof(TestQuestions), new { testId = questionModel.TestId });
        }

        public IActionResult CreateAnswer(int questionId, int testId)
        {
            return View(new AnswerModel { QuestionId = questionId, TestId = testId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnswer(AnswerModel answerModel)
        {
            await _answerService.CreateAsync(answerModel);
            return RedirectToAction(nameof(TestQuestions), new { testId = answerModel.TestId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAnswer(int id, int testId)
        {
            await _answerService.DeleteAsync(id);
            return RedirectToAction(nameof(TestQuestions), new { testId = testId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTestQuestion(int id, int testId)
        {
            await _testQuestionService.DeleteAsync(testId, id);

            return RedirectToAction(nameof(TestQuestions), new { testId = testId });
        }

        public async Task<IActionResult> DeleteTest(int? id)
        {
            if (id == null) return NotFound();

            var test = await _testService.GetByIdAsync((int)id);
            if (test == null) return NotFound();

            return View(test);
        }

        [HttpPost, ActionName("DeleteTest")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTestByIdConfirmed(int id)
        {
            await _testService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> TestDetails(int id)
        {
            var test = await _testService.GetByIdAsync(id);
            return View(test);
        }
    }
}
