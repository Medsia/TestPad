namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IResultRepository
    {
        Task<Result> GetByIdAsync(int id);
        Task<IEnumerable<Result>> GetAllAsync();
        Task<IEnumerable<Result>> GetAllByTestIdAsync(int testId);
        Task CreateAsync(Result result);
        Task UpdateAsync(Result result);
        Task DeleteAsync(Result result);
    }
}
