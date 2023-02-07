using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Controllers
{
    [Route("api/")]
    [ApiController]
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
