using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("StartTest")]
        public IActionResult StartTest()
        {
            return View();
        }
    }
}
