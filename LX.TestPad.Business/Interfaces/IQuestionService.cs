using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionModel> GetByIdAsync(int id);
    }
}
