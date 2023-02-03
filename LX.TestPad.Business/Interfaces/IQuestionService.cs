using LX.TestPad.Business.Models;
using LX.TestPad.Business.Services;

namespace LX.TestPad.Business.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionModel> GetByIdAsync(int id);
        Task<List<int>> GetAllQuestionIdsByTestId(int testId);
        Task<QuestionWithAnswersModel> GetByIdWithAnswersAsync(int id);

        Task CreateAsync(QuestionModel testModel);
        Task UpdateAsync(QuestionModel testModel);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(List<int> ids);
    }
}
