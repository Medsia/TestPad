using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    /// <summary>
    /// Gives limited access to service functionality.
    /// </summary>
    public interface IPublicTestService
    {
        Task<TestModel> GetByIdAsync(int id);
        Task<IEnumerable<TestModel>> GetAllAsync();
        Task<IEnumerable<TestModel>> GetAllByPageNumberAsync(int pageNumber, int count);
    }

    /// <summary>
    /// Gives full access to service functionality.
    /// </summary>
    public interface IPrivateTestService
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
