using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IResultService
    {
        Task<ResultModel> GetByIdAsync(int id);
        Task<List<ResultModel>> GetAllByTestIdAsync(int testId);
        Task CreateAsync(ResultModel resultModel);
        Task<int> CreateAndGetIdAsync(ResultModel resultModel);
        Task UpdateAsync(ResultModel resultModel);

        Task DeleteAsync(int id);
        Task DeleteManyAsync(List<int> ids);
    }
}
