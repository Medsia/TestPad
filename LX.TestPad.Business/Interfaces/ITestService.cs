using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface ITestService
    {
        Task<TestModel> GetByIdAsync(int id);
        Task<IEnumerable<TestModel>> GetAllAsync();
        Task<IEnumerable<TestModel>> GetAllByPageNumberAsync(int pageNumber, int count);

        Task CreateAsync(TestModel testModel);
        Task UpdateAsync(TestModel testModel);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(IEnumerable<int> ids);
    }
}
