using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.Business.Services
{
    public class TestQuestionService : ITestQuestionService
    {
        private readonly ITestQuestionRepository _testQuestionRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ITestRepository _testRepository;

        public TestQuestionService(ITestQuestionRepository testQuestionRepository, IQuestionRepository questionRepository, 
                                        ITestRepository testRepository)
        {
            _testQuestionRepository = testQuestionRepository;
            _questionRepository = questionRepository;
            _testRepository = testRepository;
        }


        public async Task<QuestionModel> GetQuestionByIdAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _questionRepository.GetByIdAsync(id);

            return Mapper.QuestionToModel(item);
        }
        public async Task<TestModel> GetTestByIdAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _testRepository.GetByIdAsync(id);

            return Mapper.TestToModel(item);
        }
        public async Task<List<TestQuestionModel>> GetAllByTestIdAsync(int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);

            var items = await _testQuestionRepository.GetAllByTestIdAsync(testId);

            return items.Select(Mapper.TestQuestionToModel)
                        .ToList();
        }

        private async Task<int> GetNewNumberByTestIdAsync(int testId)
        {
            var lastQuestion = (await _testQuestionRepository.GetAllByTestIdAsync(testId)).LastOrDefault();
            int newNumber;
            if (lastQuestion != null) newNumber = lastQuestion.Number + 1;
            else newNumber = 1;

            return newNumber;
        }



        public async Task<List<QuestionModel>> GetAllQuestionsByTestIdAsync(int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);

            var items = await _testQuestionRepository.GetAllByTestIdAsync(testId);

            List<QuestionModel> result = new List<QuestionModel>();
            foreach (var item in items)
            {
                var resultItem = await GetQuestionByIdAsync(item.Id);
                result.Add(resultItem);
            }

            return result;
        }

        public async Task<List<TestModel>> GetAllTestsByQuestionIdAsync(int questionId)
        {
            ExceptionChecker.SQLKeyIdCheck(questionId);

            var items = await _testQuestionRepository.GetAllByQuestionIdAsync(questionId);

            List<TestModel> result = new List<TestModel>();
            foreach (var item in items)
            {
                var resultItem = await GetTestByIdAsync(item.Id);
                result.Add(resultItem);
            }

            return result;
        }

        public async Task CreateAsync(int questionId, int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(questionId);
            ExceptionChecker.SQLKeyIdCheck(testId);

            var newNumber = await GetNewNumberByTestIdAsync(testId);

            var item = new TestQuestion
            {
                QuestionId = questionId,
                TestId = testId,
                Number = newNumber,
            };

            await _testQuestionRepository.CreateAsync(item);
        }

        public async Task CreateAsync(List<int> questionIds, int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);
            ExceptionChecker.ListOfSQLKeyIdsCheck(questionIds);

            foreach (var questionId in questionIds)
            {
                var newNumber = await GetNewNumberByTestIdAsync(testId);

                var item = new TestQuestion
                {
                    QuestionId = questionId,
                    TestId = testId,
                    Number = newNumber,
                };

                await _testQuestionRepository.CreateAsync(item);
            }
        }

        public async Task CreateFromAsync(int oldTestId, int newTestId)
        {
            ExceptionChecker.SQLKeyIdCheck(oldTestId);
            ExceptionChecker.SQLKeyIdCheck(newTestId);

            var sourceItems = await _testQuestionRepository.GetAllByTestIdAsync(oldTestId);

            foreach (var sourceItem in sourceItems)
            {
                var newItem = new TestQuestion
                {
                    QuestionId = sourceItem.QuestionId,
                    TestId = newTestId
                };

                await _testQuestionRepository.CreateAsync(newItem);
            }
        }

        public async Task DeleteByQuestionIdAsync(int questionId)
        {
            ExceptionChecker.SQLKeyIdCheck(questionId);

            await _testQuestionRepository.DeleteAllByQuestionIdAsync(questionId);
        }
    }
}
