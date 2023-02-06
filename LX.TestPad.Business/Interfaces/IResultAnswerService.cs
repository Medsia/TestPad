using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    public interface IResultAnswerService : IService<ResultAnswerModel>
    {
        Task<ResultAnswerModel> GetByIdAsync(int id);
        Task<List<ResultAnswerModel>> GetAllByResultIdAsync(int resultId);

        Task<ResultAnswerModel> CreateAsync(int resultId, int answerId);

        Task DeleteAllByResultIdAsync(int resultId);
    }
}
