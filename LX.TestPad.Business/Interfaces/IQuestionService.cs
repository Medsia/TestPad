using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionModel> GetByIdAsync(int id);
        Task<QuestionWithAnswersModel> GetByIdIcludingAnswersAsync(int id);

        Task<QuestionModel> CreateAsync(QuestionModel questionModel);
        Task UpdateAsync(QuestionModel questionModel);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(List<int> ids);
    }
}
