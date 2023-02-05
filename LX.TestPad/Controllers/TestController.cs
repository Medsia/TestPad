using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestQuestionService _testQuestionService;
        private readonly ITestService _testService;
        private readonly IResultService _resultService;
        private readonly IQuestionService _questionService;

        public TestController(ITestQuestionService testQuestionService, ITestService testService,
            IResultService resultService, IQuestionService questionService)
        {
            _testQuestionService = testQuestionService;
            _testService = testService;
            _resultService = resultService;
            _questionService = questionService;
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
        public async Task<IActionResult> EnterUserName(TestModel testModel, string name, string surname)
        {
            var resultModel = new ResultModel(testModel.Id, name + surname, 0, DateTime.Now, DateTime.MinValue);

            await _resultService.CreateAsync(resultModel);

            return RedirectToAction("Question", new { @testId = resultModel.TestId });
        }

        public async Task<IActionResult> Question(int testId, int num = 0)
        {
            var testQuestions = await _testQuestionService.GetAllByTestIdAsync(testId);
            var question = await _questionService.GetByIdWithAnswersAsync(testQuestions[num].QuestionId);

            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Question(QuestionWithAnswersModel question, int num = 0)
        {
            //var question = questions[num];

            return View(question);
        }

        [Route("Result")]
        public IActionResult Result()
        {
            return View();
        }
    }
}
