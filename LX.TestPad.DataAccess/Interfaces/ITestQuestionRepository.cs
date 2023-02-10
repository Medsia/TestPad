using LX.TestPad.DataAccess.Entities;

namespace LX.TestPad.DataAccess.Interfaces
{
    public interface ITestQuestionRepository : IRepository<TestQuestion>
    {
        Task<TestQuestion> GetSingleOrDefaultAsync(int testId, int questionId);
        Task<List<TestQuestion>> GetAllByTestIdAsync(int testId);
        Task<List<TestQuestion>> GetAllByQuestionIdAsync(int QuestionId);

        Task DeleteSingleAsync(int testQuestionId);
        Task DeleteSingleAsync(int testId, int questionId);
        Task DeleteAllByQuestionIdAsync(int questionId);
    }
}
