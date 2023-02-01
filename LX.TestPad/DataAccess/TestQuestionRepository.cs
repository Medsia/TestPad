using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class TestQuestionRepository : ITestQuestionRepository
    {
        private readonly DbContextFactory dbContextFactory;
        public TestQuestionRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public async Task CreateAsync(TestQuestion testQuestion)
        {
            var dbContext = dbContextFactory.Create(typeof(TestQuestionRepository));

            await dbContext.TestQuestion.AddAsync(testQuestion);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TestQuestion testQuestion)
        {
            var dbContext = dbContextFactory.Create(typeof(TestQuestionRepository));

            dbContext.TestQuestion.Remove(testQuestion);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TestQuestion>> GetAllByTestIdAsync(int testId)
        {
            var dbContext = dbContextFactory.Create(typeof(TestQuestionRepository));

            return await dbContext.TestQuestion.Where(x => x.TestId == testId).ToListAsync();
        }

        public async Task<TestQuestion> GetByIdAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(TestQuestionRepository));

            return await dbContext.TestQuestion.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(TestQuestion testQuestion)
        {
            var dbContext = dbContextFactory.Create(typeof(TestQuestionRepository));

            dbContext.Entry(testQuestion).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
