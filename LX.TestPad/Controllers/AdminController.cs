using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    public class AdminController : Controller
    {
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
        public IActionResult Questions()
        {
            return View();
        }

    }
}
