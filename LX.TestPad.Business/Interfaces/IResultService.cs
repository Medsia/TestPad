using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    /// <summary>
    /// Gives limited access to service functionality.
    /// </summary>
    public interface IPublicResultService
    {
        Task<ResultModel> GetByIdAsync(int id);
        Task<IReadOnlyCollection<ResultModel>> GetAllByTestIdAsync(int testId);
        Task CreateAsync(ResultModel testModel);
        Task UpdateAsync(ResultModel testModel);
    }

    /// <summary>
    /// Gives full access to service functionality.
    /// </summary>
    public interface IPrivateResultService
    {
        Task<ResultModel> GetByIdAsync(int id);
        Task<IReadOnlyCollection<ResultModel>> GetAllByTestIdAsync(int testId);
        Task CreateAsync(ResultModel testModel);
        Task UpdateAsync(ResultModel testModel);

        Task DeleteAsync(int id);
        Task DeleteManyAsync(IEnumerable<int> ids);
    }
}
