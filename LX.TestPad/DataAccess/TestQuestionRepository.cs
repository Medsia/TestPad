using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.DataAccess
{
    public class TestQuestionRepository : ITestQuestionRepository
    {
        public Task CreateAsync(TestQuestion testQuestion)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TestQuestion testQuestion)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TestQuestion>> GetAllByTestIdAsync(int TestId)
        {
            throw new NotImplementedException();
        }

        public Task<TestQuestion> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TestQuestion testQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
