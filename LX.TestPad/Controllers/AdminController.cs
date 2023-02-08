using LX.TestPad.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
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
