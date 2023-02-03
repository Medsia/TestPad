namespace LX.TestPad.DataAccess.Interfaces
{
    public interface ITestQuestionRepository : IRepository<TestQuestion>
    {
        Task<List<TestQuestion>> GetAllByTestIdAsync(int testId);
        Task<TestQuestion> GetByIdIncludingAsync(int id);
        Task<List<TestQuestion>> GetAllByTestIdIncludingAsync(int testId);
    }
}
