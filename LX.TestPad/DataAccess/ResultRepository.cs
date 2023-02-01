using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class ResultRepository : IResultRepository
    {
        private readonly DbContextFactory dbContextFactory;
        public ResultRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public async Task CreateAsync(Result result)
        {
            var dbContext = dbContextFactory.Create(typeof(ResultRepository));

            await dbContext.Results.AddAsync(result);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Result result)
        {
            var dbContext = dbContextFactory.Create(typeof(ResultRepository));

            dbContext.Results.Remove(result);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Result>> GetAllAsync()
        {
            var dbContext = dbContextFactory.Create(typeof(ResultRepository));

            return await dbContext.Results.ToListAsync();
        }
        public async Task<IEnumerable<Result>> GetAllByTestIdAsync(int testId)
        {
            var dbContext = dbContextFactory.Create(typeof(ResultRepository));

            return await dbContext.Results.Where(x => x.TestId == testId).ToListAsync();
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(ResultRepository));

            return await dbContext.Results.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Result result)
        {
            var dbContext = dbContextFactory.Create(typeof(ResultRepository));

            dbContext.Entry(result).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
