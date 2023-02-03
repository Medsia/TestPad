namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IResultRepository : IRepository<Result>
    {
        Task<IEnumerable<Result>> GetAllByTestIdAsync(int testId);
        Task<Result> GetByIdIncludingAsync(int id);
        Task<IEnumerable<Result>> GetAllIncludingAsync();
        Task<IEnumerable<Result>> GetAllByTestIdIncludingAsync(int testId);
    }
}
