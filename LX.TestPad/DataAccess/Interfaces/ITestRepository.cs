namespace LX.TestPad.DataAccess.Interfaces
{
    public interface ITestRepository
    {
        Task<Test> GetByIdAsync(int id);
        Task<IEnumerable<Test>> GetAllAsync();
        Task CreateAsync(Test test);
        Task UpdateAsync(Test test);
        Task DeleteAsync(Test test);
    }
}
