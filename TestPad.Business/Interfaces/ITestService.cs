using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface ITestService : IService<TestModel>
    {
        Task<List<TestModel>> GetAllByRequestAsync(string request);
        Task<TestModel> GetByIdAsync(int testId);
        Task<List<TestModel>> GetAllAsync();
        Task<List<TestModel>> GetAllByPageNumberAsync(int pageNumber, int count);
        Task<List<TestModel>> GetAllPublishedAsync();
        Task<TestModel> CopyByIdAsync(int oldTestId);
        Task<bool> CheckPublishAsync(TestModel testModel);
    }
}
