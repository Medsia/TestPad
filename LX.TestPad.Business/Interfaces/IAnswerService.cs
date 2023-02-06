using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IAnswerService : IService<AnswerModel>
    {
        Task<AnswerModel> GetByIdAsync(int id);
        Task<List<AnswerModel>> GetAllByQuestionIdAsync(int questionId);
        Task<List<CutAnswerModel>> GetAllCutByQuestionIdAsync(int questionId);

        Task DeleteAllByQuestionIdAsync(int questionId);
    }
}
