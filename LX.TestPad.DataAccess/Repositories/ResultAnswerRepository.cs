using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess.Repositories
{
    public class ResultAnswerRepository : IResultAnswerRepository
    {
        private readonly DataContext dbContext;
        
        public ResultAnswerRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(ResultAnswer resultAnswer)
        {
            await dbContext.ResultAnswers.AddAsync(resultAnswer);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ResultAnswer resultAnswer)
        {
            dbContext.ResultAnswers.Remove(resultAnswer);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<ResultAnswer>> GetAllByResultIdAsync(int resultId)
        {
            return await dbContext.ResultAnswers.Where(x => x.ResultId == resultId).ToListAsync();
        }
        public async Task<List<ResultAnswer>> GetAllAsync()
        {
            return await dbContext.ResultAnswers.ToListAsync();
        }

        public async Task<ResultAnswer> GetByIdAsync(int id)
        {
            return await dbContext.ResultAnswers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(ResultAnswer resultAnswer)
        {
            dbContext.ResultAnswers.Update(resultAnswer);

            await dbContext.SaveChangesAsync();
        }
    }
}
