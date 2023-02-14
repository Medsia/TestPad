using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.Controllers;
using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.Business.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly ITestQuestionRepository _testQuestionRepository;
        public TestService(ITestQuestionRepository testQuestionRepository, IQuestionRepository questionRepository,
                                        ITestRepository testRepository, IAnswerRepository answerRepository)
        {
            _testQuestionRepository = testQuestionRepository;
            _questionRepository = questionRepository;
            _testRepository = testRepository;
            _answerRepository = answerRepository;
        }



        public async Task<TestModel> GetByIdAsync(int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);

            var item = await _testRepository.GetByIdAsync(testId);

            return Mapper.TestToModel(item);
        }

        public async Task<List<TestModel>> GetAllAsync()
        {
            var items = await _testRepository.GetAllAsync();

            return items.Select(Mapper.TestToModel)
                        .ToList();
        }

        public async Task<List<TestModel>> GetAllPublishedAsync()
        {
            var items = await _testRepository.GetAllPublishedAsync();

            return items.Select(Mapper.TestToModel)
                        .ToList();
        }

        public async Task<List<TestModel>> GetAllByPageNumberAsync(int pageNumber, int count)
        {
            ExceptionChecker.PageNumberCheck(pageNumber);
            ExceptionChecker.TestPerPageCountCheck(count);

            var items = await _testRepository.GetAllAsync();
            var prevPages = (pageNumber - 1) * count;

            return items.Skip(prevPages).Take(count)
                        .Select(Mapper.TestToModel)
                        .ToList();
        }


        public async Task<TestModel> CreateAsync(TestModel testModel)
        {
            var item = Mapper.TestModelToEntity(testModel);

            item = await _testRepository.CreateAsync(item);
            var question = new Question { Text = BasicDataToGenerate.QuestionText };
            question = await _questionRepository.CreateAsync(question);
            var testQuestion = new TestQuestion { QuestionId = question.Id, TestId = item.Id };
            await _testQuestionRepository.CreateAsync(testQuestion);
            var answer = new Answer { QuestionId = question.Id, Text = BasicDataToGenerate.QuestionText, IsCorrect = BasicDataToGenerate.Answer.IsCorrect };
            await _answerRepository.CreateAsync(answer);
            return Mapper.TestToModel(item);
        }

        public async Task UpdateAsync(TestModel testModel)
        {
            var item = Mapper.TestModelToEntity(testModel);

            await _testRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            await _testRepository.DeleteAsync(id);
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            ExceptionChecker.ListOfSQLKeyIdsCheck(ids);

            await _testRepository.DeleteManyAsync(ids);
        }
    }
}
