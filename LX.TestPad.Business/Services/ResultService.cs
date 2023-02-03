using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.Business.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;

        public ResultService(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }


        public async Task<ResultModel> GetByIdAsync(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("id");

            var item = await _resultRepository.GetByIdAsync(id);

            return Mapper.Map(item);
        }

        public async Task<List<ResultModel>> GetAllByTestIdAsync(int testId)
        {
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            var items = await _resultRepository.GetAllByTestIdAsync(testId);

            return items.Select(Mapper.Map)
                        .ToList();
        }


        public async Task<int> CreateAsync(ResultModel testModel)
        {
            var item = Mapper.Map(testModel);

            return await _resultRepository.CreateAndGetNewItemIdAsync(item);
        }

        public async Task UpdateAsync(ResultModel testModel)
        {
            var item = Mapper.Map(testModel);

            await _resultRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _resultRepository.GetByIdAsync(id);

            await _resultRepository.DeleteAsync(item);
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            foreach (var id in ids) await DeleteAsync(id);
        }
    }
}
