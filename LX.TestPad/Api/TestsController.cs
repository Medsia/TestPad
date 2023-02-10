using LX.TestPad.Authorization;
using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly ITestQuestionService _testQuestionService;

        public TestsController(ITestService testService, ITestQuestionService testQuestionService)
        {
            _testService = testService;
            _testQuestionService = testQuestionService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTests()
        {
            var items = await _testService.GetAllAsync();
            return new OkObjectResult(items);
        }

        [HttpPut("{questionId}/{testId}")]
        public async Task AddQuestionToTest(int questionId, int testId)
        {
            await _testQuestionService.CreateAsync(questionId, testId);
        }

        [HttpDelete("{questionId}/{testId}")]
        public async Task RemoveQuestionFromTest(int questionId, int testId)
        {
            await _testQuestionService.DeleteAsync(testId, questionId);
        }
    }
}
