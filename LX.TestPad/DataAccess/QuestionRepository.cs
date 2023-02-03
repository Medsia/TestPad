using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext dbContext;
        
        public QuestionRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Question question)
        {
            await dbContext.Questions.AddAsync(question);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Question question)
        {
            dbContext.Questions.Remove(question);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await dbContext.Questions.ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await dbContext.Questions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Question question)
        {
            dbContext.Questions.Update(question);
            await dbContext.SaveChangesAsync();
        }
    }
}
