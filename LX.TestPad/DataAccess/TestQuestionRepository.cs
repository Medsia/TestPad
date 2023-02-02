using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class TestQuestionRepository : ITestQuestionRepository
    {
        private readonly DataContext dbContext;
        public TestQuestionRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(TestQuestion testQuestion)
        {

            await dbContext.TestQuestion.AddAsync(testQuestion);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TestQuestion testQuestion)
        {

            dbContext.TestQuestion.Remove(testQuestion);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TestQuestion>> GetAllByTestIdAsync(int testId)
        {

            return await dbContext.TestQuestion.Where(x => x.TestId == testId).ToListAsync();
        }
        public async Task<IEnumerable<TestQuestion>> GetAllAsync()
        {

            return await dbContext.TestQuestion.ToListAsync();
        }

        public async Task<TestQuestion> GetByIdAsync(int id)
        {

            return await dbContext.TestQuestion.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<TestQuestion>> GetAllByTestIdIncludingAsync(int testId)
        {

            return await dbContext.TestQuestion
                .Where(x => x.TestId == testId)
                .Include(x => x.Question)
                .Include(x => x.Test)
                .ToListAsync();
        }

        public async Task<TestQuestion> GetByIdIncludingAsync(int id)
        {

            return await dbContext.TestQuestion
                .Include(x => x.Question)
                .Include(x => x.Test)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(TestQuestion testQuestion)
        {

            dbContext.TestQuestion.Update(testQuestion);
            await dbContext.SaveChangesAsync();
        }
    }
}
