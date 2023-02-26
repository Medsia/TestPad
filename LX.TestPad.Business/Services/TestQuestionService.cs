using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;
using System.Security.Cryptography;

namespace LX.TestPad.Business.Services
{
    public class TestQuestionService : ITestQuestionService
    {
        private readonly ITestQuestionRepository _testQuestionRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ITestRepository _testRepository;
        private readonly IAnswerRepository _answerRepository;

        public TestQuestionService(ITestQuestionRepository testQuestionRepository, IQuestionRepository questionRepository,
                                        ITestRepository testRepository, IAnswerRepository answerRepository)
        {
            _testQuestionRepository = testQuestionRepository;
            _questionRepository = questionRepository;
            _testRepository = testRepository;
            _answerRepository = answerRepository;
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
        public async Task<List<TestQuestionModel>> GetAllByTestIdIncludeQuestionAndAnswersWithoutIsCorrectAsync(int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);

            var testQuestions = await _testQuestionRepository.GetAllByTestIdIncludeQuestionAndAnswersAsync(testId);
            foreach (var testQuestion in testQuestions)
            {
                testQuestion.Question = Mapper.QuestionWithAnswersToQuestionWithoutIsCorrect(testQuestion.Question);
            }

            return testQuestions.Select(Mapper.TestQuestionWithAnswersAndTestToModel)
                        .ToList();
        }
        public async Task<TestQuestionModel> GetNextByTestIdIncludeQuestionAndAnswersWithoutIsCorrectAsync(int testId, int questionNumber)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);

            var nextTestQuestion = await _testQuestionRepository.GetNextByTestIdIncludeQuestionAndAnswersAsync(testId, questionNumber);

            // return defaultTestQuestion if nextTestQuestion is null
            if (nextTestQuestion == null)
            {
                TestQuestionModel defaultTestQuestion = new TestQuestionModel();
                return defaultTestQuestion;
            }

            nextTestQuestion.Question = Mapper.QuestionWithAnswersToQuestionWithoutIsCorrect(nextTestQuestion.Question);

            return Mapper.TestQuestionWithAnswersAndTestToModel(nextTestQuestion);
        }
        public async Task<List<TestQuestionModel>> GetAllByTestIdIncludeQuestionsWithAnswersAsync(int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);

            var testQuestions = await _testQuestionRepository.GetAllByTestIdIncludeQuestionAndAnswersAsync(testId);

            return testQuestions.Select(Mapper.TestQuestionWithAnswersAndTestToModel)
                        .ToList();
        }

        public async Task<List<TestQuestionModel>> GetAllByTestIdExceptTestIncludeQuestionsWithAnswersAsync(int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);

            var testQuestions = await _testQuestionRepository.GetAllByTestIdExceptTestIncludeQuestionAndAnswersAsync(testId);

            return testQuestions.Select(Mapper.TestQuestionWithAnswersAndTestToModel)
                        .ToList();
        }

        private async Task<int> GetNewQuestionSequenceNumberByTestIdAsync(int testId)
        {
            var lastQuestion = (await _testQuestionRepository.GetAllByTestIdAsync(testId)).LastOrDefault();
            return lastQuestion == null ? 1 : lastQuestion.Number + 1;
        }


        public async Task<List<QuestionModel>> GetAllUnusedQuestionsAsync()
        {
            var items = await _questionRepository.GetAllUnusedAsync();

            if (items.Count == 0) return new List<QuestionModel>();

            return items.Select(Mapper.QuestionToModel)
                        .ToList();
        }

        public async Task<List<QuestionModel>> GetAllQuestionsByTestIdAsync(int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);

            var items = await _testQuestionRepository.GetAllByTestIdAsync(testId);

            List<QuestionModel> result = new List<QuestionModel>();
            foreach (var item in items)
            {
                var resultItem = await GetQuestionByIdAsync(item.QuestionId);
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

            var existingTestQuestion = await _testQuestionRepository.GetSingleOrDefaultAsync(testId, questionId);
            if (existingTestQuestion == null)
            {
                var newNumber = await GetNewQuestionSequenceNumberByTestIdAsync(testId);

                var item = new TestQuestion
                {
                    QuestionId = questionId,
                    TestId = testId,
                    Number = newNumber,
                };

                await _testQuestionRepository.CreateAsync(item);
            }
        }

        public async Task CreateAsync(List<int> questionIds, int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);
            ExceptionChecker.ListOfSQLKeyIdsCheck(questionIds);

            foreach (var questionId in questionIds)
            {
                var newNumber = await GetNewQuestionSequenceNumberByTestIdAsync(testId);

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

        public async Task DeleteAsync(int testId, int questionId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);
            ExceptionChecker.SQLKeyIdCheck(questionId);

            await _testQuestionRepository.DeleteSingleAsync(testId, questionId);
        }

        public async Task DeleteAllByQuestionIdAsync(int questionId)
        {
            ExceptionChecker.SQLKeyIdCheck(questionId);

            await _testQuestionRepository.DeleteAllByQuestionIdAsync(questionId);
        }
    }
}
