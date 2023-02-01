using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class TestRepository : ITestRepository
    {
        private readonly DbContextFactory dbContextFactory;
        public TestRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public async Task CreateAsync(Test test)
        {
            var dbContext = dbContextFactory.Create(typeof(TestRepository));

            await dbContext.Tests.AddAsync(test);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Test test)
        {
            var dbContext = dbContextFactory.Create(typeof(TestRepository));

            dbContext.Tests.Remove(test);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Test>> GetAllAsync()
        {
            var dbContext = dbContextFactory.Create(typeof(TestRepository));

            return await dbContext.Tests.ToListAsync();
        }

        public async Task<Test> GetByIdAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(TestRepository));

            return await dbContext.Tests.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Test test)
        {
            var dbContext = dbContextFactory.Create(typeof(TestRepository));

            dbContext.Entry(test).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
