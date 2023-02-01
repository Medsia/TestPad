using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class TestRepository : ITestRepository
    {
        private DataContext db = new DataContext();
        public async Task CreateAsync(Test test)
        {
            await db.Tests.AddAsync(test);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Test test)
        {
            db.Tests.Remove(test);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Test>> GetAllAsync()
        {
            return await db.Tests.ToListAsync();
        }

        public async Task<Test> GetByIdAsync(int id)
        {
            return await db.Tests.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Test test)
        {
            db.Entry(test).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
