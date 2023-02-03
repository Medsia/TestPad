namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
