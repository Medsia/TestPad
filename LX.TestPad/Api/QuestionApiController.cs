using LX.TestPad.Authorization;
using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Api
{
    [Route("Api/QuestionApi")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
    public class QuestionApiController : ControllerBase
    {
        private readonly ITestQuestionService _testQuestionService;

        public QuestionApiController(ITestQuestionService testQuestionService)
        {
            _testQuestionService = testQuestionService;
        }


        [HttpGet("GetUnusedQuestions")]
        public async Task<ActionResult<List<QuestionModel>>> GetUnusedQuestions()
        {
            var items = await _testQuestionService.GetAllUnusedQuestionsAsync();
            return new ObjectResult(items);
        }

        [HttpGet("GetQuestions/{testId}")]
        public async Task<ActionResult<List<QuestionModel>>> GetQuestions(int testId)
        {
            var items = await _testQuestionService.GetAllQuestionsByTestIdAsync(testId);
            return new ObjectResult(items);
        }

        [HttpPost("AddQuestionToTest/{testId}/{questionId}")]
        public async Task AddQuestionToTest(int testId, int questionId)
        {
            await _testQuestionService.CreateAsync(questionId, testId);
        }

        [HttpPost("RemoveQuestionFromTest/{testId}/{questionId}")]
        public async Task RemoveQuestionFromTest(int testId, int questionId)
        {
            await _testQuestionService.DeleteAsync(testId, questionId);
        }
    }
}
