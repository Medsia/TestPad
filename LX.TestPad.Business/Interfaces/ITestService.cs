using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface ITestService
    {
        Task<TestModel> GetByIdAsync(int testId);
        Task<List<TestModel>> GetAllAsync();
        Task<List<TestModel>> GetAllByPageNumberAsync(int pageNumber, int count);

        Task<TestModel> CreateAsync(TestModel testModel);
        Task UpdateAsync(TestModel testModel);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(List<int> ids);
    }
}
