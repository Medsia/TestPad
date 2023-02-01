using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess;

namespace LX.TestPad.Business.Services
{
    public class TestQuestionService : ITestQuestionService
    {
        private readonly ITestQuestionRepository _testQuestionRepository;
        private readonly IQuestionService _questionService;

        public TestQuestionService(ITestQuestionRepository testQuestionRepository, IQuestionService questionService)
        {
            _testQuestionRepository = testQuestionRepository;
            _questionService = questionService;
        }


        public async Task<IEnumerable<QuestionModel>> GetAllQuestionsByTestIdAsync(int testId)
        {
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            var items = await _testQuestionRepository.GetAllByTestIdAsync(testId);

            List<QuestionModel> result = new List<QuestionModel>();
            foreach (var item in items)
            {
                var resultItem = await _questionService.GetByIdAsync(item.Id);
                result.Add(resultItem);
            }

            return result;
        }

        public async Task<IEnumerable<QuestionModel>> GetAllTestsByQuestionIdAsync(int questionId)
        {
            if (questionId < 1)
                throw new ArgumentOutOfRangeException("questionId");

            var items = await _testQuestionRepository.GetAllByQuestionIdAsync(questionId);

            List<QuestionModel> result = new List<QuestionModel>();
            foreach (var item in items)
            {
                var resultItem = await _questionService.GetByIdAsync(item.Id);
                result.Add(resultItem);
            }

            return result;
        }


        public async Task LinkQuestionToTest(int questionId, int testId)
        {
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            if (questionId < 1)
                throw new ArgumentOutOfRangeException("questionId");

            var item = new TestQuestion
            {
                QuestionId = questionId,
                TestId = testId
            };

            await _testQuestionRepository.CreateAsync(item);
        }

        public async Task LinkQuestionsToTest(IEnumerable<int> questionIds, int testId)
        {
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            if (questionIds.Any(id => id < 1))
                throw new ArgumentOutOfRangeException("questionIds");

            foreach (var questionId in questionIds)
            {
                var item = new TestQuestion
                {
                    QuestionId = questionId,
                    TestId = testId
                };

                await _testQuestionRepository.CreateAsync(item);
            }
        }

        public async Task LinkQuestionsFromTestToAnotherTest(int fromTestId, int toTestId)
        {
            if (fromTestId < 1)
                throw new ArgumentOutOfRangeException("fromTestId");

            if (toTestId < 1)
                throw new ArgumentOutOfRangeException("toTestId");

            var sourceItems = await _testQuestionRepository.GetAllByTestIdAsync(fromTestId);

            foreach (var sourceItem in sourceItems)
            {
                var newItem = new TestQuestion
                {
                    QuestionId = sourceItem.QuestionId,
                    TestId = toTestId
                };

                await _testQuestionRepository.CreateAsync(newItem);
            }
        }


        public async Task DeleteByQuestionIdAsync(int questionId)
        {
            if (questionId < 1)
                throw new ArgumentOutOfRangeException("questionId");

            var items = await GetAllTestsByQuestionIdAsync(questionId);

            foreach (var item in items) await _testQuestionRepository.DeleteAsync(item);
        }
    }
}
