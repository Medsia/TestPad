using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess.Repositories
{
    public class ResultAnswerRepository : IResultAnswerRepository
    {
        private readonly DataContext dbContext;

        public ResultAnswerRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ResultAnswer> CreateAsync(ResultAnswer resultAnswer)
        {
            await dbContext.ResultAnswers.AddAsync(resultAnswer);
            await dbContext.SaveChangesAsync();

            return resultAnswer;
        }
        public async Task CreateRangeAsync(params ResultAnswer[] resultAnswer)
        {
            await dbContext.ResultAnswers.AddRangeAsync(resultAnswer);
            await dbContext.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            var item = await dbContext.ResultAnswers.FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                dbContext.ResultAnswers.Remove(item);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteManyAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var item = await dbContext.ResultAnswers.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null) dbContext.ResultAnswers.Remove(item);
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<ResultAnswer>> GetAllByResultIdAsync(int resultId)
        {
            return await dbContext.ResultAnswers.Where(x => x.ResultId == resultId).ToListAsync();
        }
        public async Task<List<ResultAnswer>> GetAllAsync()
        {
            return await dbContext.ResultAnswers.ToListAsync();
        }

        public async Task<ResultAnswer> GetByIdAsync(int id)
        {
            return await dbContext.ResultAnswers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(ResultAnswer resultAnswer)
        {
            dbContext.ResultAnswers.Update(resultAnswer);

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAllByResultIdAsync(int resultId)
        {
            var items = await dbContext.ResultAnswers.Where(x => x.ResultId == resultId).ToListAsync();
            if (items.Count == 0) return;

            foreach (var item in items) dbContext.ResultAnswers.Remove(item);

            await dbContext.SaveChangesAsync();
        }

        public async Task<int> CountAllCorrectAsync(int resultId)
        {
            return (await dbContext.ResultAnswers.Where(x => x.ResultId == resultId && x.IsCorrect).ToListAsync()).Count;
        }

        public async Task<int> CountAllCorrectByQuestionIdAsync(int resultId, int questionId)
        {
            int count = 0;
            var resultAnswers = await dbContext.ResultAnswers.Where(x => x.ResultId == resultId).ToListAsync();
            var question = await dbContext.Questions.SingleOrDefaultAsync(x => x.Id == questionId);
            if (question == null) return count;

            foreach (var resultAnswer in resultAnswers)
            {
                if (resultAnswer.QuestionText == question.Text && resultAnswer.IsCorrect) count++;
            }

            return count;
        }

        public async Task<bool> IsAnyIncorrectAsync(int resultId, int questionId)
        {
            var resultAnswers = await dbContext.ResultAnswers.Where(x => x.ResultId == resultId).ToListAsync();
            foreach (var resultAnswer in resultAnswers)
            {
                if (await dbContext.Questions.AnyAsync(x => x.Id == questionId && x.Text == resultAnswer.QuestionText)
                    && !resultAnswer.IsCorrect) 
                        return true;
            }

            return false;
        }
    }
}
