using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    public class AdminController : Controller
    {
        private readonly ITestQuestionService _testQuestionService;
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;

        public AdminController(ITestQuestionService testQuestionService, ITestService testService,
            IQuestionService questionService)
        {
            _testQuestionService = testQuestionService;
            _testService = testService;
            _questionService = questionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestResults()
        {
            return View();
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
            return View(new TestModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTest(TestModel testModel)
        {
            await _testService.CreateAsync(testModel);
            return RedirectToAction(nameof(TestDetails), testModel);
        }

        public IActionResult Questions()
        {
            return View();
        }

        public IActionResult CreateAnswer()
        {
            return View();
        }

        public IActionResult DeleteTest()
        {
            return View();
        }
        public IActionResult TestDetails(TestModel testModel)
        {
            return View(testModel);
        }
    }
}
