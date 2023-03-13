using LX.TestPad.Authorization;
using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LX.TestPad.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly ITestQuestionService _testQuestionService;

        public TestsController(ITestService testService, ITestQuestionService testQuestionService)
        {
            _testService = testService;
            _testQuestionService = testQuestionService;
        }


        [HttpGet("filter/published")]
        public async Task<IActionResult> GetAllPublishedTests()
        {
            var items = await _testService.GetAllPublishedAsync();
            return Ok(items);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
        public async Task<IActionResult> GetAllTests()
        {
            var items = await _testService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetAllTestsBySearchRequest([FromQuery, Required] string request)
        {
            try
            {
                var items = await _testService.GetAllByRequestAsync(request);
                return Ok(items);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{questionId}/{testId}")]
        [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
        public async Task AddQuestionToTest(int questionId, int testId)
        {
            await _testQuestionService.CreateAsync(questionId, testId);
        }

        [HttpDelete("{questionId}/{testId}")]
        [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
        public async Task RemoveQuestionFromTest(int questionId, int testId)
        {
            await _testQuestionService.DeleteAsync(testId, questionId);
        }
    }
}
