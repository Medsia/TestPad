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


        public async Task<TestModel> GetByIdAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _testRepository.GetByIdAsync(id);

            return Mapper.Map(item);
        }

        public async Task<List<TestModel>> GetAllAsync()
        {
            var items = await _testRepository.GetAllAsync();

            return items.Select(Mapper.Map)
                        .ToList();
        }

        public async Task<List<TestModel>> GetAllByPageNumberAsync(int pageNumber, int maxCount)
        {
            ExceptionChecker.PageNumberCheck(pageNumber);
            ExceptionChecker.TestPerPageCountCheck(maxCount);

            var items = await _testRepository.GetAllAsync();
            var prevPages = (pageNumber - 1) * maxCount;

            return items.Skip(prevPages).Take(maxCount)
                        .Select(Mapper.Map)
                        .ToList();
        }


        public async Task CreateAsync(TestModel testModel)
        {
            var item = Mapper.Map(testModel);

            await _testRepository.CreateAsync(item);
        }

        public async Task UpdateAsync(TestModel testModel)
        {
            var item = Mapper.Map(testModel);

            await _testRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _testRepository.GetByIdAsync(id);

            await _testRepository.DeleteAsync(item);
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            foreach (var id in ids) await DeleteAsync(id);
        }
    }
}
