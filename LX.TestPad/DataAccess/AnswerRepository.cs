using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.DataAccess
{
    public class AnswerRepository : IAnswerRepository
    {
        public Task CreateAsync(Answer answer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Answer answer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Answer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Answer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
