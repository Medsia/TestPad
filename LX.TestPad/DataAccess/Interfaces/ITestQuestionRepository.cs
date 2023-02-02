namespace LX.TestPad.DataAccess.Interfaces
{
    public interface ITestQuestionRepository : IRepository<TestQuestion>
    {
        Task<IEnumerable<TestQuestion>> GetAllByTestIdAsync(int testId);
        Task<TestQuestion> GetByIdIncludingAsync(int id);
        Task<IEnumerable<TestQuestion>> GetAllByTestIdIncludingAsync(int testId);
    }
}
