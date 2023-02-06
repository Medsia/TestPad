using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface ITestQuestionService
    {
        Task<List<QuestionModel>> GetAllQuestionsByTestIdAsync(int testId);
        Task<List<TestModel>> GetAllTestsByQuestionIdAsync(int questionId);

        Task<List<TestQuestionModel>> GetAllByTestIdAsync(int testId);
        Task CreateAsync(int questionId, int testId);
        Task CreateAsync(List<int> questionIds, int testId);
        Task CreateFromAsync(int oldTestId, int newTestId);
        Task DeleteByQuestionIdAsync(int questionId);
    }
}
