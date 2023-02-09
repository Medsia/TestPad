using LX.TestPad.Authorization;
using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Api
{
    [Route("Api/TestApi")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
    public class TestApiController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestApiController(ITestService testService)
        {
            _testService = testService;
        }


        [HttpGet("GetAllTests")]
        public async Task<ActionResult<List<TestModel>>> GetAllTests()
        {
            var items = await _testService.GetAllAsync();
            return new ObjectResult(items);
        }
    }
}
