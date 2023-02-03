namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IResultAnswerRepository : IRepository<ResultAnswer>
    {
        Task<List<ResultAnswer>> GetAllByResultIdAsync(int resultId);
    }
}
