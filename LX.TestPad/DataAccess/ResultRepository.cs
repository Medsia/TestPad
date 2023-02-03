using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class ResultRepository : IResultRepository
    {
        private readonly DataContext dbContext;
        
        public ResultRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task CreateAsync(Result result)
        {
            await dbContext.Results.AddAsync(result);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Result result)
        {
            dbContext.Results.Remove(result);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Result>> GetAllAsync()
        {
            return await dbContext.Results.ToListAsync();
        }

        public async Task<List<Result>> GetAllByTestIdAsync(int testId)
        {
            return await dbContext.Results.Where(x => x.TestId == testId).ToListAsync();
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            return await dbContext.Results.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Result result)
        {
            dbContext.Results.Update(result);
            await dbContext.SaveChangesAsync();
        }
    }
}
