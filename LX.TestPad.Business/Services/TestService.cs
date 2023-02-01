using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Services
{
    public class TestService : IPrivateTestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }


        public async Task<TestModel> GetByIdAsync(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("id");

            var item = await _testRepository.GetByIdAsync(id);

            return Mapper.Map(item);
        }

        public async Task<IEnumerable<TestModel>> GetAllAsync()
        {
            var items = await _testRepository.GetAllAsync();

            return items.Select(Mapper.Map)
                        .ToArray();
        }

        public async Task<IEnumerable<TestModel>> GetPartAsync(int startId, int count)
        {
            if (startId < 1)
                throw new ArgumentOutOfRangeException("startId");

            if(count == 0)
                throw new ArgumentOutOfRangeException("count");

            var items = await _testRepository.GetAllAsync();

            return items.Skip(startId).Take(count)
                        .Select(Mapper.Map)
                        .ToArray();
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
            var item = _testRepository.GetByIdAsync(id);

            await _testRepository.DeleteAsync(item);
        }

        public async Task DeleteManyAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids) await DeleteAsync(id);
        }
    }
}
