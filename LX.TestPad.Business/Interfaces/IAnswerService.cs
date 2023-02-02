using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IAnswerService
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
