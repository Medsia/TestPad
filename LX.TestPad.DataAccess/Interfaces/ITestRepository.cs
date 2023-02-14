using LX.TestPad.DataAccess.Entities;

namespace LX.TestPad.DataAccess.Interfaces
{
    public interface ITestRepository : IRepository<Test>
    {
        Task<List<Test>> GetAllPublishedAsync();
    }
}
