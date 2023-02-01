using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly DbContextFactory dbContextFactory;
        public AnswerRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public async Task CreateAsync(Answer answer)
        {
            var dbContext = dbContextFactory.Create(typeof(AnswerRepository));

            await dbContext.Answers.AddAsync(answer);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Answer answer)
        {
            var dbContext = dbContextFactory.Create(typeof(AnswerRepository));

            dbContext.Answers.Remove(answer);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Answer>> GetAllByQuestionIdAsync(int questionId)
        {
            var dbContext = dbContextFactory.Create(typeof(AnswerRepository));

            return await dbContext.Answers.Where(x => x.QuestionId == questionId).ToListAsync();
        }
        public async Task<IEnumerable<Answer>> GetAllByQuestionIdIncludingAsync(int questionId)
        {
            var dbContext = dbContextFactory.Create(typeof(AnswerRepository));

            return await dbContext.Answers
                .Where(x => x.QuestionId == questionId)
                .Include(x => x.Question)
                .ToListAsync();
        }

        public async Task<Answer> GetByIdAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(AnswerRepository));

            return await dbContext.Answers.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Answer> GetByIdIncludingAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(AnswerRepository));

            return await dbContext.Answers
                .Include(x => x.Question)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Answer answer)
        {
            var dbContext = dbContextFactory.Create(typeof(AnswerRepository));

            dbContext.Entry(answer).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
