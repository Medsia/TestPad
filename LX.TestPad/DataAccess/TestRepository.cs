using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.DataAccess
{
    public class TestRepository : ITestRepository
    {
        private DataContext db = new DataContext();
        public Task CreateAsync(Test test)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Test test)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Test>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Test> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Test test)
        {
            throw new NotImplementedException();
        }
    }
}
