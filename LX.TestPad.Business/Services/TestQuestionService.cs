using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess;
using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.Business.Services
{
    public class TestQuestionService : ITestQuestionService
    {
        private readonly ITestQuestionRepository _testQuestionRepository;
        private readonly IQuestionRepository _questionRepository;

        public TestQuestionService(ITestQuestionRepository testQuestionRepository, IQuestionRepository questionRepository)
        {
            _testQuestionRepository = testQuestionRepository;
            _questionRepository = questionRepository;
        }


        public async Task<QuestionModel> GetQuestionByIdAsync(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("id");

            var item = await _questionRepository.GetByIdAsync(id);

            return Mapper.Map(item);
        }


        public async Task<List<TestQuestionModel>> GetAllByTestIdAsync(int testId)
        {
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            var items = await _testQuestionRepository.GetAllByTestIdAsync(testId);

            return items.Select(Mapper.Map)
                        .ToList();
        }

        public async Task<List<QuestionModel>> GetAllQuestionsByTestIdAsync(int testId)
        {
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            var items = await _testQuestionRepository.GetAllByTestIdAsync(testId);

            List<QuestionModel> result = new List<QuestionModel>();
            foreach (var item in items)
            {
                var resultItem = await GetQuestionByIdAsync(item.Id);
                result.Add(resultItem);
            }

            return result;
        }

        public async Task<List<QuestionModel>> GetAllTestsByQuestionIdAsync(int questionId)
        {
            if (questionId < 1)
                throw new ArgumentOutOfRangeException("questionId");

            var items = await _testQuestionRepository.GetAllByQuestionIdAsync(questionId);

            List<QuestionModel> result = new List<QuestionModel>();
            foreach (var item in items)
            {
                var resultItem = await GetQuestionByIdAsync(item.Id);
                result.Add(resultItem);
            }

            return result;
        }


        private async Task<int> GetNewNumberByTestId(int testId)
        {
            var lastQuestion = (await _testQuestionRepository.GetAllByTestIdAsync(testId)).LastOrDefault();
            int newNumber;
            if (lastQuestion != null) newNumber = lastQuestion.Number + 1;
            else newNumber = 1;

            return newNumber;
        }

        public async Task LinkQuestionToTest(int questionId, int testId)
        {
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            if (questionId < 1)
                throw new ArgumentOutOfRangeException("questionId");

            var newNumber = await GetNewNumberByTestId(testId);

            var item = new TestQuestion
            {
                QuestionId = questionId,
                TestId = testId,
                Number = newNumber,
            };

            await _testQuestionRepository.CreateAsync(item);
        }

        public async Task LinkQuestionsToTest(List<int> questionIds, int testId)
        {
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            if (questionIds.Any(id => id < 1))
                throw new ArgumentOutOfRangeException("questionIds");

            foreach (var questionId in questionIds)
            {
                var newNumber = await GetNewNumberByTestId(testId);

                var item = new TestQuestion
                {
                    QuestionId = questionId,
                    TestId = testId,
                    Number = newNumber,
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

            var items = await _testQuestionRepository.GetAllByQuestionIdAsync(questionId);

            foreach (var item in items) await _testQuestionRepository.DeleteAsync(item);
        }
    }
}
