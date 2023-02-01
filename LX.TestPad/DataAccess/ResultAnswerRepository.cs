using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.DataAccess
{
    public class ResultAnswerRepository : IResultAnswerRepository
    {
        public Task CreateAsync(ResultAnswer resultAnswer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResultAnswer resultAnswer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResultAnswer>> GetAllByResultIdAsync(int resultId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultAnswer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ResultAnswer resultAnswer)
        {
            throw new NotImplementedException();
        }
    }
}
