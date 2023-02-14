using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.Business.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
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


        public async Task<TestModel> CopyByIdAsync(int id)
        {
            var selectedTest = await _testRepository.GetByIdAsync(id);
            var newTest = new Test()
            {
                Name = selectedTest.Name + $" (Copy_of_{selectedTest.Name})",
                Description = selectedTest.Description,
                TestDuration = selectedTest.TestDuration,
                IsPublished = false,
            };

            var item = await _testRepository.CreateAsync(newTest);

            return Mapper.TestToModel(item);
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
