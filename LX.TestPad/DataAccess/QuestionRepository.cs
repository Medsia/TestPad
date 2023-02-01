using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class QuestionRepository : IQuestionRepository
    {
        private DataContext db = new DataContext();
        public async Task CreateAsync(Question question)
        {
            await db.Questions.AddAsync(question);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Question question)
        {
            db.Questions.Remove(question);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await db.Questions.ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await db.Questions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Question question)
        {
            db.Entry(question).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
