using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class TestQuestionRepository : ITestQuestionRepository
    {
        private DataContext db = new DataContext();
        public async Task CreateAsync(TestQuestion testQuestion)
        {
            await db.TestQuestion.AddAsync(testQuestion);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(TestQuestion testQuestion)
        {
            db.TestQuestion.Remove(testQuestion);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TestQuestion>> GetAllByTestIdAsync(int testId)
        {
            return await db.TestQuestion.Where(x => x.TestId == testId).ToListAsync();
        }

        public async Task<TestQuestion> GetByIdAsync(int id)
        {
            return await db.TestQuestion.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(TestQuestion testQuestion)
        {
            db.Entry(testQuestion).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
