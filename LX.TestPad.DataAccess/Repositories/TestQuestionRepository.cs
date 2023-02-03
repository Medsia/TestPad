using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess.Repositories
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

        public async Task<List<TestQuestion>> GetAllByTestIdAsync(int testId)
        {
            return await dbContext.TestQuestion.Where(x => x.TestId == testId).ToListAsync();
        }

        public async Task<List<TestQuestion>> GetAllByQuestionIdAsync(int QuestionId)
        {
            return await dbContext.TestQuestion.Where(x => x.QuestionId == QuestionId).ToListAsync();
        }

        public async Task<List<TestQuestion>> GetAllAsync()
        {
            return await dbContext.TestQuestion.ToListAsync();
        }

        public async Task<TestQuestion> GetByIdAsync(int id)
        {
            return await dbContext.TestQuestion.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(TestQuestion testQuestion)
        {
            dbContext.TestQuestion.Update(testQuestion);
            await dbContext.SaveChangesAsync();
        }
    }
}
