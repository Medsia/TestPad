using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface ITestQuestionService
    {
        Task<List<QuestionModel>> GetAllQuestionsByTestIdAsync(int testId);
        Task<List<QuestionModel>> GetAllTestsByQuestionIdAsync(int questionId);
        Task<List<TestQuestionModel>> GetAllByTestIdAsync(int testId);
        Task LinkQuestionToTest(int questionId, int testId);
        Task LinkQuestionsToTest(List<int> questionIds, int testId);
        Task LinkQuestionsFromTestToAnotherTest(int fromTestId, int toTestId);
        Task DeleteByQuestionIdAsync(int questionId);
    }
}
