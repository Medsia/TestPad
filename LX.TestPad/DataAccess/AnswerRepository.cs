using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class AnswerRepository : IAnswerRepository
    {
        private DataContext db = new DataContext();
        public async Task CreateAsync(Answer answer)
        {
            await db.Answers.AddAsync(answer);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Answer answer)
        {
            db.Answers.Remove(answer);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Answer>> GetAllByQuestionIdAsync(int questionId)
        {
            return await db.Answers.Where(x => x.QuestionId == questionId).ToListAsync();
        }

        public async Task<Answer> GetByIdAsync(int id)
        {
            return await db.Answers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Answer answer)
        {
            db.Entry(answer).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
