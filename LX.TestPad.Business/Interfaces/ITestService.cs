using LX.TestPad.Business.Models;
using LX.TestPad.Business.Services;

namespace LX.TestPad.Business.Interfaces
{
    /// <summary>
    /// Gives limited access to service functionality.
    /// </summary>
    public interface IPublicTestService
    {
        Task<TestModel> GetByIdAsync(int id);
        Task<IEnumerable<TestModel>> GetAllAsync();
        Task<IEnumerable<TestModel>> GetPartAsync(int startId, int count);
    }

    /// <summary>
    /// Gives full access to service functionality.
    /// </summary>
    public interface IPrivateTestService
    {
        Task<TestModel> GetByIdAsync(int id);
        Task<IEnumerable<TestModel>> GetAllAsync();
        Task<IEnumerable<TestModel>> GetPartAsync(int startId, int count);

        Task CreateAsync(TestModel testModel);
        Task UpdateAsync(TestModel testModel);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(IEnumerable<int> ids);
    }
}
