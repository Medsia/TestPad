using LX.TestPad.Business.Interfaces;
using LX.TestPad.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LX.TestPad.DataAccess;

namespace LX.TestPad.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestService _testService;

        public HomeController(ILogger<HomeController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        public async Task<IActionResult> Index()
        {
            var tests = await _testService.GetAllAsync();

            return View(tests);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}