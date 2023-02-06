using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess.Repositories
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

        public async Task DeleteAsync(int id)
        {
            var item = await dbContext.Tests.FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                dbContext.Tests.Remove(item);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteManyAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var item = await dbContext.Tests.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null) dbContext.Tests.Remove(item);
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Test>> GetAllAsync()
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
