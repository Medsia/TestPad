using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly DataContext dbContext;

        public ResultRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> CreateAsync(Result result)
        {
            await dbContext.Results.AddAsync(result);
            await dbContext.SaveChangesAsync();

            return result;
        }


        public async Task DeleteAsync(int id)
        {
            var item = await dbContext.Results.FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                dbContext.Results.Remove(item);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteManyAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var item = await dbContext.Results.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null) dbContext.Results.Remove(item);
            }

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

        public async Task<List<Result>> GetAllIncludeTestAsync()
        {
            return await dbContext.Results.Include(x => x.Test).ToListAsync();
        }

        public async Task<Result> GetByIdIncludeTestAsync(int id)
        {
            return await dbContext.Results.Include(x => x.Test).FirstOrDefaultAsync(y => y.Id == id);
        }
    }
}
