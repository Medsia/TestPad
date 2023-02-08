using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    public class AuthController : Controller
    {
        [Authorize, Route("Auth")]
        public IActionResult Auth()
        {
            return View();
        }
    }
}
