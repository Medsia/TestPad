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
        public async Task<IActionResult> EnterUserName(TestModel testModel, string name, string surname)
        {
            var resultModel = await _resultService.CreateAsync(new ResultModel(testModel.Id, name + surname, 0, DateTime.Now, DateTime.MinValue));

            return RedirectToAction(nameof(Question), new { @resultId = resultModel.Id });
        }

        public async Task<IActionResult> Question(int resultId, int num = 0)
        {
            var result = await _resultService.GetByIdAsync(resultId);
            var testQuestions = await _testQuestionService.GetAllByTestIdAsync(result.TestId);
            if (num >= testQuestions.Count)
                return RedirectToAction(nameof(Result));
            var question = await _questionService.GetByIdIcludingAnswersAsync(testQuestions[num].QuestionId);

            ViewBag.resultId = resultId;
            ViewBag.num = num;

            return View(question);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Question(QuestionWithAnswersModel question, int resultId,
            int answerId, int num)
        {
            await _resultAnswerService.CreateAsync(resultId, answerId);

            return RedirectToAction(nameof(Question), new { @resultId = resultId, @num = num + 1 });
        }

        [Route("Result")]
        public IActionResult Result()
        {
            return View();
        }
    }
}
