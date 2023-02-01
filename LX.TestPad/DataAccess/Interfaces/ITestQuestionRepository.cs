namespace LX.TestPad.DataAccess.Interfaces
{
    public interface ITestQuestionRepository
    {
        Task<TestQuestion> GetByIdAsync(int id);
        Task<IEnumerable<TestQuestion>> GetAllByTestIdAsync(int TestId);
        Task CreateAsync(TestQuestion testQuestion);
        Task UpdateAsync(TestQuestion testQuestion);
        Task DeleteAsync(TestQuestion testQuestion);
    }
}
