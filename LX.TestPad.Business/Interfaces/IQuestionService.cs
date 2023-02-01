using LX.TestPad.Business.Models;
using LX.TestPad.Business.Services;

namespace LX.TestPad.Business.Interfaces
{
    /// <summary>
    /// Gives limited access to service functionality.
    /// </summary>
    public interface IPublicQuestionService
    {
        Task<QuestionModel> GetByIdAsync(int id);
    }

    /// <summary>
    /// Gives full access to service functionality.
    /// </summary>
    public interface IPrivateQuestionService
    {
        Task<QuestionModel> GetByIdAsync(int id);

        Task CreateAsync(QuestionModel testModel);
        Task UpdateAsync(QuestionModel testModel);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(IEnumerable<int> ids);
    }
}
