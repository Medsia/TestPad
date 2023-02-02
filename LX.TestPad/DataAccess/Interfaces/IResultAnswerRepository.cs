namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IResultAnswerRepository : IRepository<ResultAnswer>
    {
        Task<IEnumerable<ResultAnswer>> GetAllByResultIdAsync(int resultId);
        Task<ResultAnswer> GetByIdIncludingAsync(int id);
        Task<IEnumerable<ResultAnswer>> GetAllByResultIdIncludingAsync(int resultId);
    }
}
