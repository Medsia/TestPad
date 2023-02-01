using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.DataAccess
{
    public class ResultRepository : IResultRepository
    {
        public Task CreateAsync(Result result)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Result result)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Result>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Answer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Result result)
        {
            throw new NotImplementedException();
        }
    }
}
