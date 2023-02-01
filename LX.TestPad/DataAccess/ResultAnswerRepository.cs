using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class ResultAnswerRepository : IResultAnswerRepository
    {
        private readonly DbContextFactory dbContextFactory;
        public ResultAnswerRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public async Task CreateAsync(ResultAnswer resultAnswer)
        {
            var dbContext = dbContextFactory.Create(typeof(ResultAnswerRepository));

            await dbContext.ResultAnswers.AddAsync(resultAnswer);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ResultAnswer resultAnswer)
        {
            var dbContext = dbContextFactory.Create(typeof(ResultAnswerRepository));

            dbContext.ResultAnswers.Remove(resultAnswer);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ResultAnswer>> GetAllByResultIdAsync(int resultId)
        {
            var dbContext = dbContextFactory.Create(typeof(ResultAnswerRepository));

            return await dbContext.ResultAnswers.Where(x => x.ResultId == resultId).ToListAsync();
        }

        public async Task<ResultAnswer> GetByIdAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(ResultAnswerRepository));

            return await dbContext.ResultAnswers.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<ResultAnswer>> GetAllByResultIdIncludingAsync(int resultId)
        {
            var dbContext = dbContextFactory.Create(typeof(ResultAnswerRepository));

            return await dbContext.ResultAnswers
                .Where(x => x.ResultId == resultId)
                .Include(x => x.Result)
                .ToListAsync();
        }

        public async Task<ResultAnswer> GetByIdIncludingAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(ResultAnswerRepository));

            return await dbContext.ResultAnswers
                .Include(x => x.Result)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(ResultAnswer resultAnswer)
        {
            var dbContext = dbContextFactory.Create(typeof(ResultAnswerRepository));

            dbContext.Entry(resultAnswer).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
