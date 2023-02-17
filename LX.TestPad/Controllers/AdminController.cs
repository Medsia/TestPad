using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.Authorization;
using LX.TestPad.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LX.TestPad.DataAccess.Entities;
using LX.TestPad.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.IdentityModel.Tokens;

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
        private readonly IResultAnswerService _resultAnswerService;
        public AdminController(ITestQuestionService testQuestionService, ITestService testService,
            IQuestionService questionService, IAnswerService answerService, IResultService resultService,
            IResultAnswerService resultAnswerService)
        {
            _testQuestionService = testQuestionService;
            _testService = testService;
            _questionService = questionService;
            _answerService = answerService;
            _resultService = resultService;
            _resultAnswerService = resultAnswerService;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

        public async Task<IActionResult> ResultDetails(int resultId)
        {
            try
            {
                var resultModel = await _resultService.GetByIdIncludeTestAsync(resultId);
                var resultAnswerModels = (await _resultAnswerService.GetAllByResultIdAsync(resultId)).GroupBy(x => x.QuestionText).ToList();

                return View(new ResultWithResultAnswersViewModel { ResultModel = resultModel, ResultAnswerModels = resultAnswerModels });
            }
            catch
            {
                return RedirectToAction(nameof(Error));
            }
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
            return RedirectToAction(nameof(TestDetails), new { id = test.Id }); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeIsPublishedTest(TestModel test)
        {
            var isValid = await _testService.CheckPublishAsync(test);
            if (isValid)
            {
                test.IsPublished = !test.IsPublished;
            }
            else
            {
                test.IsPublished = false;
            }
            await _testService.UpdateAsync(test);
            return RedirectToAction(nameof(TestDetails), new { id = test.Id });
        }

        public async Task<IActionResult> MakeTestPrivate(TestModel test)
        {
            test.IsPublished = false;
            await _testService.UpdateAsync(test);
            return RedirectToAction(nameof(TestQuestions), new { testId = test.Id });
        }

        public async Task<IActionResult> TestQuestions(int testId)

        {
            var testQuestions = await _testQuestionService.GetAllByTestIdIncludeQuestionsWithAnswersAsync(testId);
            ViewBag.TestId = testId;
            return View(testQuestions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CopyTest(int selectedTestId)
        {
            var newTest = await _testService.CopyByIdAsync(selectedTestId);

            int minIdValue = 0;
            if (newTest.Id <= minIdValue) return RedirectToAction(nameof(Error));

            return RedirectToAction(nameof(TestDetails), new { id = newTest.Id });

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
            return RedirectToAction(nameof(TestQuestions), new { testId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTestQuestion(int id, int testId)
        {
            await _testQuestionService.DeleteAsync(testId, id);
            return RedirectToAction(nameof(TestQuestions), new { testId });
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
            var isValid = await _testService.CheckPublishAsync(test);
            ViewBag.isValid = isValid;
            return View(test);
        }
    }
}
