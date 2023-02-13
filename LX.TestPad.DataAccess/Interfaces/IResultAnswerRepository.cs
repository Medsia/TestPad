using LX.TestPad.DataAccess.Entities;

namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IResultAnswerRepository : IRepository<ResultAnswer>
    {
        Task<List<ResultAnswer>> GetAllByResultIdAsync(int resultId);
        Task DeleteAllByResultIdAsync(int resultId);
        Task CreateRangeAsync(params ResultAnswer[] resultAnswer);

        Task<int> CountAllCorrectAsync(int resultId);
        Task<int> CountAllCorrectByQuestionIdAsync(int resultId, int questionId);
        Task<bool> IsAnyIncorrectAsync(int resultId, int questionId);
    }
}
