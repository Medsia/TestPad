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
        public async Task<Question> CreateAsync(Question question)
        {
            await dbContext.Questions.AddAsync(question);
            await dbContext.SaveChangesAsync();

            return question;
        }
        private async Task DeleteTestQuestionsByQuestionIdAsync(int questionId)
        {
            var items = await dbContext.TestQuestion.Where(x => x.QuestionId == questionId).ToListAsync();
            if (items.Count == 0) return;

            foreach (var item in items) dbContext.TestQuestion.Remove(item);
        }
        private async Task DeleteAllAsnwersByQuestionIdAsync(int questionId)
        {
            var items = await dbContext.Answers.Where(x => x.QuestionId == questionId).ToListAsync();
            if (items.Count == 0) return;

            foreach (var item in items) dbContext.Answers.Remove(item);
        }
        public async Task DeleteAsync(int id)
        {
            var item = dbContext.Questions.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                await DeleteTestQuestionsByQuestionIdAsync(id);
                await DeleteAllAsnwersByQuestionIdAsync(id);

                dbContext.Questions.Remove(item);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteManyAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var item = await dbContext.Questions.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null)
                {
                    await DeleteTestQuestionsByQuestionIdAsync(id);
                    await DeleteAllAsnwersByQuestionIdAsync(id);

                    dbContext.Questions.Remove(item);
                }
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Question>> GetAllAsync()
        {
            return await dbContext.Questions.ToListAsync();
        }

        public async Task<List<Question>> GetAllUnusedAsync()
        {
            var items = await dbContext.Questions.ToListAsync();

            var result = new List<Question>();
            foreach (var item in items)
            {
                var isAnyDBRecord = await dbContext.TestQuestion.AnyAsync(x => x.QuestionId == item.Id);
                if (!isAnyDBRecord) result.Add(item);
            }

            return result;
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
