using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface ITestService
    {
        Task<TestModel> GetByIdAsync(int id);
        Task<IEnumerable<TestModel>> GetAllAsync();
        Task<IEnumerable<TestModel>> GetPartAsync(int startId, int count);
    }
}
