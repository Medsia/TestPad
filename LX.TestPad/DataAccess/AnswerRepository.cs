using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly DataContext dbContext;
        public AnswerRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Answer answer)
        {

            await dbContext.Answers.AddAsync(answer);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Answer answer)
        {

            dbContext.Answers.Remove(answer);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Answer>> GetAllAsync()
        {
            return await dbContext.Answers.ToListAsync();
        }

        public async Task<IEnumerable<Answer>> GetAllByQuestionIdAsync(int questionId)
        {

            return await dbContext.Answers.Where(x => x.QuestionId == questionId).ToListAsync();
        }
        public async Task<IEnumerable<Answer>> GetAllByQuestionIdIncludingAsync(int questionId)
        {

            return await dbContext.Answers
                .Where(x => x.QuestionId == questionId)
                .Include(x => x.Question)
                .ToListAsync();
        }

        public async Task<Answer> GetByIdAsync(int id)
        {

            return await dbContext.Answers.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Answer> GetByIdIncludingAsync(int id)
        {

            return await dbContext.Answers
                .Include(x => x.Question)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Answer answer)
        {

            dbContext.Answers.Update(answer);
            await dbContext.SaveChangesAsync();
        }
    }
}
