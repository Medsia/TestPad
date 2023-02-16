using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;
using LX.TestPad.DataAccess.Repositories;

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


        private async Task CopyAllTestQuestionsToNewTestAsync(int oldTestId, int newTestId)
        {
            ExceptionChecker.SQLKeyIdCheck(oldTestId);
            ExceptionChecker.SQLKeyIdCheck(newTestId);

            var oldTestQuestionIds = (await _testQuestionRepository.GetAllByTestIdAsync(oldTestId)).Select(x => x.QuestionId);
            var newTestQuestions = oldTestQuestionIds.Select(x => new TestQuestion { TestId = newTestId, QuestionId = x }).ToList();

            await _testQuestionRepository.CreateFromListAsync(newTestQuestions);
        }
        public async Task<TestModel> CopyByIdAsync(int oldTestId)
        {
            ExceptionChecker.SQLKeyIdCheck(oldTestId);

            var selectedTest = await _testRepository.GetByIdAsync(oldTestId);
            if (selectedTest == null) return new TestModel();

            var newTest = new Test()
            {
                Name = selectedTest.Name + $" (Copy)",
                Description = selectedTest.Description,
                TestDuration = selectedTest.TestDuration,
                IsPublished = false,
            };

            var item = await _testRepository.CreateAsync(newTest);
            await CopyAllTestQuestionsToNewTestAsync(oldTestId, newTest.Id);

            return Mapper.TestToModel(item);
        }


        public async Task<List<TestModel>> GetAllByRequestAsync(string request)
        {
            ExceptionChecker.IsRequestAValidString(request);

            var items = await _testRepository.GetByRequestAsync(request.ToLower());
            ExceptionChecker.IsItemNullCheck(items);

            return items.Select(Mapper.TestToModel)
                        .ToList();
        }


        public async Task<TestModel> CreateAsync(TestModel testModel)
        {
            var item = Mapper.TestModelToEntity(testModel);

            item = await _testRepository.CreateAsync(item);
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
