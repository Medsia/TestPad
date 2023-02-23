using LX.TestPad.DataAccess.Entities;

namespace LX.TestPad.DataAccess.Interfaces
{
    public interface ITestQuestionRepository : IRepository<TestQuestion>
    {
        Task<TestQuestion> GetSingleOrDefaultAsync(int testId, int questionId);
        Task<List<TestQuestion>> GetAllByTestIdAsync(int testId);
        Task<List<TestQuestion>> GetAllByTestIdIncludeQuestionsAsync(int testId);
        Task<List<TestQuestion>> GetAllByTestIdIncludeQuestionAndAnswersAsync(int testId);
        Task<TestQuestion> GetNextByTestIdIncludeQuestionAndAnswersAsync(int testId, int questionNumber);
        Task<List<TestQuestion>> GetAllByTestIdExceptTestIncludeQuestionAndAnswersAsync(int testId);
        Task<List<TestQuestion>> GetAllByQuestionIdAsync(int QuestionId);
        Task CreateFromListAsync(List<TestQuestion> testQuestions);
        Task DeleteSingleAsync(int testQuestionId);
        Task DeleteSingleAsync(int testId, int questionId);
        Task DeleteAllByQuestionIdAsync(int questionId);
    }
}
