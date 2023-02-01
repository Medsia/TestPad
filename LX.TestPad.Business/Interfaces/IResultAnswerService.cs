using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IResultAnswerService
    {
        Task<ResultAnswerModel> GetByIdAsync(int id);
        Task<IEnumerable<ResultAnswerModel>> GetAllByResultIdAsync(int resultId);
    }
}
