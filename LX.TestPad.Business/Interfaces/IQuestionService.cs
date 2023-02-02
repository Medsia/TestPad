using LX.TestPad.Business.Models;
using LX.TestPad.Business.Services;

namespace LX.TestPad.Business.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionModel> GetByIdAsync(int id);
        Task<IEnumerable<int>> GetAllQuestionIdsByTestId(int testId);

        Task CreateAsync(QuestionModel testModel);
        Task UpdateAsync(QuestionModel testModel);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(IEnumerable<int> ids);
    }
}
