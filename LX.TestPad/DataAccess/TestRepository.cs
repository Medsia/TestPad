using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class TestRepository : ITestRepository
    {
        private readonly DataContext dbContext;
        
        public TestRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Test test)
        {
            await dbContext.Tests.AddAsync(test);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Test test)
        {
            dbContext.Tests.Remove(test);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Test>> GetAllAsync()
        {
            return await dbContext.Tests.ToListAsync();
        }

        public async Task<Test> GetByIdAsync(int id)
        {
            return await dbContext.Tests.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Test test)
        {
            dbContext.Tests.Update(test);
            await dbContext.SaveChangesAsync();
        }
    }
}
