using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IResultService : IService<ResultModel>
    {
        Task<ResultModel> GetByIdAsync(int id);
        Task<List<ResultModel>> GetAllByTestIdAsync(int testId);
        Task<ResultModel> GetByIdAndCalculateAsync(int id);
        Task<List<ResultModel>> GetAllAsync();
        Task<List<ResultIncludeTestModel>> GetAllIncludeTestAsync();

    }
}
