﻿using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> EnterUserName(int id)
        {
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
                NormalizedUserName = resultModel.UserName.ToUpperInvariant()[0] + resultModel.UserSurname.ToUpperInvariant(),
                Score = 0,
                StartedAt = DateTime.Now,
                FinishedAt = DateTime.MinValue
            });

            return RedirectToAction(nameof(Question), new UserTestQuestion { ResultId = emptyUserResult.Id });
        }

        public async Task<IActionResult> Question(UserTestQuestion userTestQuestion)
        {
            var result = await _resultService.GetByIdAsync(userTestQuestion.ResultId);
            var testQuestions = await _testQuestionService.GetAllByTestIdAsync(result.TestId);

            if (userTestQuestion.QuestionNumber >= testQuestions.Count)
                return RedirectToAction(nameof(Result));

            var question = await _questionService.
                GetByIdIcludingAnswersWithoutIsCorrectAsync(testQuestions[userTestQuestion.QuestionNumber].QuestionId);

            ViewBag.resultId = result.Id;
            ViewBag.questionNumber = userTestQuestion.QuestionNumber;

            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendUserAnswer(UserAnswerModel UserAnswerModel)
        {
            await _resultAnswerService.AddUserResultAnswersAsync(UserAnswerModel.ResultId,
                UserAnswerModel.AnswersIds);
            return RedirectToAction(nameof(Question), new UserTestQuestion
            {
                ResultId = UserAnswerModel.ResultId,
                QuestionNumber = UserAnswerModel.QuestionNumber + 1
            });
        }

        [Route("Result")]
        public IActionResult Result()
        {
            return View();
        }
    }
}
