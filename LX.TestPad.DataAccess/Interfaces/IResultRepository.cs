using LX.TestPad.DataAccess.Entities;

namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IResultRepository : IRepository<Result>
    {
        Task<List<Result>> GetAllByTestIdAsync(int testId);
        Task<List<Result>> GetAllIncludeTestAsync();
    }
}
