using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    /// <summary>
    /// Gives limited access to service functionality.
    /// </summary>
    public interface IPublicAnswerService
    {
        Task<AnswerModel> GetByIdAsync(int id);
        Task<IReadOnlyCollection<AnswerModel>> GetAllByQuestionIdAsync(int testId);
    }

    /// <summary>
    /// Gives full access to service functionality.
    /// </summary>
    public interface IPrivateAnswerService
    {
        Task<AnswerModel> GetByIdAsync(int id);
        Task<IReadOnlyCollection<AnswerModel>> GetAllByQuestionIdAsync(int testId);

        Task CreateAsync(AnswerModel testModel);
        Task UpdateAsync(AnswerModel testModel);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(IEnumerable<int> ids);
        Task DeleteAllByQuestionIdAsync(int questionId);
    }
}
