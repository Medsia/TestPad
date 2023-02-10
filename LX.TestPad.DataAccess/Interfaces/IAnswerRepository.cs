using LX.TestPad.DataAccess.Entities;

namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<List<Answer>> GetAllByQuestionIdAsync(int questionId);
        Task<List<Answer>> GetAllCorrectByQuestionIdAsync(int questionId);

        Task<List<Answer>> GetAllByIdsAsync(params int[] answersIds);
        Task DeleteAllByQuestionIdAsync(int questionId);
    }
}
