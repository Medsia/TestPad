﻿using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace LX.TestPad.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestQuestionService _testQuestionService;
        private readonly ITestService _testService;
        private readonly IResultService _resultService;
        private readonly IQuestionService _questionService;
        private readonly IResultAnswerService _resultAnswerService;

        public TestController(ITestQuestionService testQuestionService, ITestService testService,
            IResultService resultService, IQuestionService questionService, IResultAnswerService resultAnswerService)
        {
            _testQuestionService = testQuestionService;
            _testService = testService;
            _resultService = resultService;
            _questionService = questionService;
            _resultAnswerService = resultAnswerService;
        }

        public IActionResult Index()
        {
            var tests = _testService.GetAllAsync();

            return View(tests);
        }

        [Route("StartTest/{id}")]
        public async Task<IActionResult> EnterUserName(int id)
        {
            TempData.Clear();
            var test = await _testService.GetByIdAsync(id);

            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePreliminaryUserResultForTest(ResultModel resultModel)
        {
            var emptyUserResult = await _resultService.CreateAsync(new ResultModel
            {
                TestId = resultModel.TestId,
                UserName = resultModel.UserName,
                UserSurname = resultModel.UserSurname,
                Score = 0,
                StartedAt = DateTime.Now.ToUniversalTime(),
                FinishedAt = DateTime.MinValue
            });
            return RedirectToAction(nameof(Question), new { resultId = emptyUserResult.Id });
        }

        [Route("{resultId}")]
        public async Task<IActionResult> Question(int resultId)
        {
            var result = await _resultService.GetByIdAsync(resultId);
            var testQuestions = await _testQuestionService.GetAllByTestIdAsync(result.TestId);
            int questionNumber = (int?)TempData["questionNumber"] ?? 0;

            if (questionNumber >= testQuestions.Count)
            {
                TempData.Clear();
                return RedirectToAction(nameof(Result));
            }

            TempData["questionNumber"] = questionNumber;

            var question = await _questionService.
                GetByIdIcludingAnswersWithoutIsCorrectAsync(testQuestions[questionNumber].QuestionId);
            var test = await _testService.GetByIdAsync(result.TestId);
            
            ViewBag.resultId = result.Id;
            ViewBag.endedAt = result.StartedAt.AddSeconds(test.TestDuration).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendUserAnswer(UserAnswerModel UserAnswerModel)
        {
            int questionNumber = (int)TempData["questionNumber"];
            TempData["questionNumber"] = ++questionNumber;

            await _resultAnswerService.AddUserResultAnswersAsync(UserAnswerModel.ResultId,
                UserAnswerModel.AnswersIds);

            return RedirectToAction(nameof(Question), new { resultId = UserAnswerModel.ResultId });
        }

        [Route("Result")]
        public IActionResult Result()
        {
            return View();
        }
    }
}
