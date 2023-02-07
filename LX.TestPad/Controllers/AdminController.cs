using LX.TestPad.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    public class AdminController : Controller
    {
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;

        public AdminController(IQuestionService questionService, ITestService testService)
        {
            _questionService = questionService;
            _testService = testService;
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


        public async Task<IActionResult> Questions()
        {
            ViewBag.Tests = await _testService.GetAllAsync();
            ViewBag.Questions = await _questionService.GetAllAsync();
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


        public IActionResult TestDetails()
        {
            return View();
        }
    }
}
