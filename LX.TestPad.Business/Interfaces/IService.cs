
namespace LX.TestPad.Business.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> CreateAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(List<int> ids);
    }
}
