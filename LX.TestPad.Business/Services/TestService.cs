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


        public async Task CreateAsync(TestModel testModel)
        {
            var item = Mapper.TestModelToEntity(testModel);

            await _testRepository.CreateAsync(item);
        }

        public async Task UpdateAsync(TestModel testModel)
        {
            var item = Mapper.TestModelToEntity(testModel);

            await _testRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);

            await _testRepository.DeleteAsync(testId);
        }

        public async Task DeleteManyAsync(List<int> testIds)
        {
            ExceptionChecker.ListOfSQLKeyIdsCheck(testIds);

            await _testRepository.DeleteManyAsync(testIds);
        }
    }
}
