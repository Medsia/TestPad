using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IAnswerService
    {
        Task<AnswerModel> GetByIdAsync(int id);
        Task<IReadOnlyCollection<AnswerModel>> GetAllByQuestionIdAsync(int testId);
    }
}
