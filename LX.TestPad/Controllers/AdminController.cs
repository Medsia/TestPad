using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    //[Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
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

        public async Task<IActionResult> Index()
        {
            var tests = await _testService.GetAllAsync();

            return View(tests);
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
            var @test = await _testService.CreateAsync(testModel);
            return RedirectToAction(nameof(TestDetails), new { @id = @test.Id });
        }

        public async Task<IActionResult> Questions(int testId)
        {
            var testQuestions = await _testQuestionService.GetAllByTestIdIncludedAsync(testId);
            return View(testQuestions);
        }

        public IActionResult CreateAnswer()
        {
            return View();
        }

        public async Task<IActionResult> DeleteTest(int? id)
        {
            if (id == null) return NotFound();

            var @test = await _testService.GetByIdAsync((int)id);
            if (@test == null) return NotFound();

            return View(@test);
        }

        [HttpPost, ActionName("DeleteTest")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _testService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> TestDetails(int id)
        
        {
            var @test = await _testService.GetByIdAsync(id);
            return View(@test);
        }
    }
}
