using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Interfaces
{
    /// <summary>
    /// Gives limited access to service functionality.
    /// </summary>
    public interface IPublicResultAnswerService
    {
        Task<ResultAnswerModel> GetByIdAsync(int id);
        Task<IEnumerable<ResultAnswerModel>> GetAllByResultIdAsync(int resultId);
        Task CreateAsync(int resultId, int answerId);
        Task UpdateAsync(ResultAnswerModel model);
    }

    /// <summary>
    /// Gives full access to service functionality.
    /// </summary>
    public interface IPrivateResultAnswerService
    {
        Task<ResultAnswerModel> GetByIdAsync(int id);
        Task<IEnumerable<ResultAnswerModel>> GetAllByResultIdAsync(int resultId);
        Task CreateAsync(int resultId, int answerId);
        Task UpdateAsync(ResultAnswerModel model);

        Task DeleteAsync(int id);
        Task DeleteAsync(ResultAnswerModel model);
        Task DeleteAllByResultIdAsync(int resultId);
    }
}
