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

        public TestController(ITestQuestionService testQuestionService, ITestService testService,
            IResultService resultService)
        {
            _testQuestionService = testQuestionService;
            _testService = testService;
            _resultService = resultService;
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

            return RedirectToAction("Question");
        }

        [Route("Question")]
        public IActionResult Question(TestModel testModel)
        {
            return View();
        }

        [Route("Result")]
        public IActionResult Result()
        {
            return View();
        }
    }
}
