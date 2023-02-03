namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IResultRepository : IRepository<Result>
    {
        Task<List<Result>> GetAllByTestIdAsync(int testId);
        Task<Result> GetByIdIncludingAsync(int id);
        Task<List<Result>> GetAllIncludingAsync();
        Task<List<Result>> GetAllByTestIdIncludingAsync(int testId);
    }
}
