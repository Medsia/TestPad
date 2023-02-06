using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess.Repositories
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

        public async Task DeleteAsync(int id)
        {
            var item = dbContext.Questions.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                dbContext.Questions.Remove(item);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var item = await dbContext.Questions.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null) dbContext.Questions.Remove(item);
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Question>> GetAllAsync()
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
