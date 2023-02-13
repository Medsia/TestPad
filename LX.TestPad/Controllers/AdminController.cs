using LX.TestPad.Authorization;
using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
    public class AdminController : Controller
    {
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;
        private readonly ITestQuestionService _testQuestionService;
        private readonly IResultService _resultService;

        public AdminController(IQuestionService questionService, ITestService testService, ITestQuestionService testQuestionService, IResultService resultService)
        {
            _questionService = questionService;
            _testService = testService;
            _testQuestionService = testQuestionService;
            _resultService = resultService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> TestResults()
        {
            var results = await _resultService.GetAllAsync();
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
