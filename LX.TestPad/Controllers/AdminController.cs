﻿using Microsoft.AspNetCore.Mvc;

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

    }
}
