using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class ResultRepository : IResultRepository
    {
        private DataContext db = new DataContext();
        public async Task CreateAsync(Result result)
        {
            await db.Results.AddAsync(result);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Result result)
        {
            db.Results.Remove(result);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Result>> GetAllAsync()
        {
            return await db.Results.ToListAsync();
        }
        public async Task<IEnumerable<Result>> GetAllByTestIdAsync(int testId)
        {
            return await db.Results.Where(x => x.TestId == testId).ToListAsync();
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            return await db.Results.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Result result)
        {
            db.Entry(result).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
