using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IResultService
    {
        Task<ResultModel> GetByIdAsync(int id);
        Task<IReadOnlyCollection<ResultModel>> GetAllByTestIdAsync(int testId);
        Task CreateAsync(ResultModel testModel);
        Task UpdateAsync(ResultModel testModel);

        Task DeleteAsync(int id);
        Task DeleteManyAsync(IEnumerable<int> ids);
    }
}
