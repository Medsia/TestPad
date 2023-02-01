using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DbContextFactory dbContextFactory;
        public QuestionRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public async Task CreateAsync(Question question)
        {
            var dbContext = dbContextFactory.Create(typeof(QuestionRepository));

            await dbContext.Questions.AddAsync(question);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Question question)
        {
            var dbContext = dbContextFactory.Create(typeof(QuestionRepository));

            dbContext.Questions.Remove(question);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            var dbContext = dbContextFactory.Create(typeof(QuestionRepository));

            return await dbContext.Questions.ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(QuestionRepository));

            return await dbContext.Questions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Question question)
        {
            var dbContext = dbContextFactory.Create(typeof(QuestionRepository));

            dbContext.Entry(question).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
