using LX.TestPad.DataAccess.Entities;

namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IResultAnswerRepository : IRepository<ResultAnswer>
    {
        Task<List<ResultAnswer>> GetAllByResultIdAsync(int resultId);
        Task<List<ResultAnswer>> GetAllCorrectByResultIdAsync(int resultId);
        Task DeleteAllByResultIdAsync(int resultId);
        Task CreateRangeAsync(params ResultAnswer[] resultAnswer);
    }
}
