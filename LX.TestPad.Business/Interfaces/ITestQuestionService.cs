using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    /// <summary>
    /// Gives limited access to service functionality.
    /// </summary>
    public interface IPublicTestQuestionService
    {
        Task<IEnumerable<QuestionModel>> GetAllQuestionsByTestIdAsync(int testId);
        Task<IEnumerable<QuestionModel>> GetAllTestsByQuestionIdAsync(int questionId);
    }

    /// <summary>
    /// Gives full access to service functionality.
    /// </summary>
    public interface IPrivateTestQuestionService
    {
        Task<IEnumerable<QuestionModel>> GetAllQuestionsByTestIdAsync(int testId);
        Task<IEnumerable<QuestionModel>> GetAllTestsByQuestionIdAsync(int questionId);

        Task LinkQuestionToTest(int questionId, int testId);
        Task LinkQuestionsToTest(IEnumerable<int> questionIds, int testId);
        Task LinkQuestionsFromTestToAnotherTest(int fromTestId, int toTestId);
        Task DeleteByQuestionIdAsync(int questionId);
    }
}
