namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IResultRepository
    {
        Task<Answer> GetByIdAsync(int id);
        Task<IEnumerable<Result>> GetAllAsync();
        Task CreateAsync(Result result);
        Task UpdateAsync(Result result);
        Task DeleteAsync(Result result);
    }
}
