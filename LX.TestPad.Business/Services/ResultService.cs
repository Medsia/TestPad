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
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _resultRepository.GetByIdAsync(id);

            return Mapper.ResultToModel(item);
        }

        public async Task<List<ResultModel>> GetAllByTestIdAsync(int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);

            var items = await _resultRepository.GetAllByTestIdAsync(testId);

            return items.Select(Mapper.ResultToModel)
                        .ToList();
        }

        public async Task CreateAsync(ResultModel resultModel)
        {
            var item = Mapper.ResultModelToEntity(resultModel);

            await _resultRepository.CreateAndGetNewItemIdAsync(item);
        }

        public async Task<int> CreateAndGetIdAsync(ResultModel resultModel)
        {
            var item = Mapper.ResultModelToEntity(resultModel);

            return await _resultRepository.CreateAndGetNewItemIdAsync(item);
        }

        public async Task UpdateAsync(ResultModel resultModel)
        {
            var item = Mapper.ResultModelToEntity(resultModel);

            await _resultRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            await _resultRepository.DeleteAsync(id);
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            ExceptionChecker.ListOfSQLKeyIdsCheck(ids);

            await _resultRepository.DeleteManyAsync(ids);
        }
    }
}
