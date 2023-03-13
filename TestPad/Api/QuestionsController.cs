using LX.TestPad.Authorization;
using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
    public class QuestionsController : ControllerBase
    {
        private readonly ITestQuestionService _testQuestionService;

        public QuestionsController(ITestQuestionService testQuestionService)
        {
            _testQuestionService = testQuestionService;
        }

        [HttpGet("unused")]
        public async Task<IActionResult> GetUnusedQuestions()
        {
            var items = await _testQuestionService.GetAllUnusedQuestionsAsync();
            return Ok(items);
        }

        [HttpGet("{testId}")]
        public async Task<IActionResult> GetQuestions(int testId)
        {
            var items = await _testQuestionService.GetAllQuestionsByTestIdAsync(testId);
            return Ok(items);
        }
    }
}
