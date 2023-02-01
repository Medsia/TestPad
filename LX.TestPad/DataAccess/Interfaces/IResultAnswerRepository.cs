namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IResultAnswerRepository
    {
        Task<ResultAnswer> GetByIdAsync(int id);
        Task<IEnumerable<ResultAnswer>> GetAllByResultIdAsync(int resultId);
        Task CreateAsync(ResultAnswer resultAnswer);
        Task UpdateAsync(ResultAnswer resultAnswer);
        Task DeleteAsync(ResultAnswer resultAnswer);
    }
}
