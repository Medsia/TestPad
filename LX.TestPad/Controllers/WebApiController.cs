using LX.TestPad.Authorization;
using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LX.TestPad.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
    public class WebApiController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;
        private readonly ITestQuestionService _testQuestionService;

        public WebApiController(IQuestionService questionService, ITestService testService, 
                                ITestQuestionService testQuestionService)
        {
            _questionService = questionService;
            _testService = testService;
            _testQuestionService = testQuestionService;
        }


        // Tests
        [HttpGet("tests/GetAllTests")]
        public async Task<ActionResult<List<TestModel>>> GetAllTests()
        {
            var items = await _testService.GetAllAsync();
            return new ObjectResult(items);
        }


        // Questions
        [HttpGet("questions/GetUnusedQuestions")]
        public async Task<ActionResult<List<QuestionModel>>> GetUnusedQuestions()
        {
            var items = await _testQuestionService.GetAllUnusedQuestionsAsync();
            return new ObjectResult(items);
        }

        [HttpGet("questions/GetQuestions/{testId}")]
        public async Task<ActionResult<List<QuestionModel>>> GetQuestions(int testId)
        {
            var items = await _testQuestionService.GetAllQuestionsByTestIdAsync(testId);
            return new ObjectResult(items);
        }

        [HttpPost("questions/AddQuestionToTest/{testId}/{questionId}")]
        public async Task AddQuestionToTest(int testId, int questionId)
        {
            await _testQuestionService.CreateAsync(questionId, testId);
        }

        [HttpPost("questions/RemoveQuestionFromTest/{testId}/{questionId}")]
        public async Task RemoveQuestionFromTest(int testId, int questionId)
        {
            await _testQuestionService.DeleteAsync(testId, questionId);
        }
    }
}
