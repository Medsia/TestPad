using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IResultAnswerService
    {
        Task<ResultAnswerModel> GetByIdAsync(int id);
        Task<List<ResultAnswerModel>> GetAllByResultIdAsync(int resultId);
        Task CreateAsync(int resultId, int answerId);
        Task UpdateAsync(ResultAnswerModel model);

        Task DeleteAsync(int id);
        Task DeleteAsync(ResultAnswerModel model);
        Task DeleteAllByResultIdAsync(int resultId);
    }
}
