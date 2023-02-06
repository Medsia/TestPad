using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IAnswerService
    {
        Task<AnswerModel> GetByIdAsync(int id);
        Task<List<AnswerModel>> GetAllByQuestionIdAsync(int testId);

        // <<summary>>
        // Returns List of cut models, which does not contain IsCorrect field
        // <<\summary>>
        Task<List<CutAnswerModel>> GetAllForClientByQuestionIdAsync(int testId);

        Task CreateAsync(AnswerModel testModel);
        Task UpdateAsync(AnswerModel testModel);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(List<int> ids);
        Task DeleteAllByQuestionIdAsync(int questionId);
    }
}
