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

        public async Task DeleteAsync(int id)
        {
            var item = dbContext.TestQuestion.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                dbContext.TestQuestion.Remove(item);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var item = await dbContext.TestQuestion.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null) dbContext.TestQuestion.Remove(item);
            }

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

        public async Task DeleteAllByQuestionIdAsync(int questionId)
        {
            var items = await dbContext.TestQuestion.Where(x => x.QuestionId == questionId).ToListAsync();
            if (items.Count == 0) return;

            foreach (var item in items) dbContext.TestQuestion.Remove(item);

            await dbContext.SaveChangesAsync();
        }
    }
}
