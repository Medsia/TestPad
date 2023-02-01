namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IResultRepository
    {
        Task<Result> GetByIdAsync(int id);
        Task<IEnumerable<Result>> GetAllAsync();
        Task<IEnumerable<Result>> GetAllByTestIdAsync(int testId);
        Task<Result> GetByIdIncludingAsync(int id);
        Task<IEnumerable<Result>> GetAllIncludingAsync();
        Task<IEnumerable<Result>> GetAllByTestIdIncludingAsync(int testId);
        Task CreateAsync(Result result);
        Task UpdateAsync(Result result);
        Task DeleteAsync(Result result);
    }
}
