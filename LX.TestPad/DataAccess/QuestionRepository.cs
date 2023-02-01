using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.DataAccess
{
    public class QuestionRepository : IQuestionRepository
    {
        public Task CreateAsync(Question question)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Question question)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
