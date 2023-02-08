using LX.TestPad.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    public class AdminController : Controller
    {
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;
        private readonly ITestQuestionService _testQuestionService;

        public AdminController(IQuestionService questionService, ITestService testService, ITestQuestionService testQuestionService)
        {
            _questionService = questionService;
            _testService = testService;
            _testQuestionService = testQuestionService;
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
            return View();
        }


        public IActionResult ExistingQuestions(int testId)
        {
            return View(testId);
        }


        public IActionResult CreateAnswer()
        {
            return View();
        }


        public IActionResult DeleteTest()
        {
            return View();
        }


        public IActionResult TestDetails()
        {
            return View();
        }
    }
}
