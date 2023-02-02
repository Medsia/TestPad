using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface ITestQuestionService
    {
        Task<IEnumerable<QuestionModel>> GetAllQuestionsByTestIdAsync(int testId);
        Task<IEnumerable<QuestionModel>> GetAllTestsByQuestionIdAsync(int questionId);

        Task<IEnumerable<TestQuestionModel>> GetAllByTestIdAsync(int testId);
        Task LinkQuestionToTest(int questionId, int testId);
        Task LinkQuestionsToTest(IEnumerable<int> questionIds, int testId);
        Task LinkQuestionsFromTestToAnotherTest(int fromTestId, int toTestId);
        Task DeleteByQuestionIdAsync(int questionId);
    }
}
