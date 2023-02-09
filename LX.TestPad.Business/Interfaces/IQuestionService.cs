using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IQuestionService : IService<QuestionModel>
    {
        Task<QuestionModel> GetByIdAsync(int id);
        Task<QuestionWithAnswersModel> GetByIdIcludingAnswersAsync(int id);
        Task<QuestionWithAnswersModel> GetByIdIcludingAnswersWithoutIsCorrectAsync(int id);
    }
}
