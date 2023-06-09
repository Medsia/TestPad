﻿using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly DataContext dbContext;

        public AnswerRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Answer> CreateAsync(Answer answer)
        {
            await dbContext.Answers.AddAsync(answer);
            await dbContext.SaveChangesAsync();

            return answer;
        }
        public async Task<Answer> CreateBasicAnswerAsync(int questionId)
        {
            var answer = new Answer { QuestionId = questionId, Text = BasicDataToGenerate.AnswerText, IsCorrect = BasicDataToGenerate.AnswerIsCorrect };
            await dbContext.Answers.AddAsync(answer);
            await dbContext.SaveChangesAsync();

            return answer;
        }
        public async Task DeleteAsync(int id)
        {
            var item = await dbContext.Answers.FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                dbContext.Answers.Remove(item);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteManyAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var item = await dbContext.Answers.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null) dbContext.Answers.Remove(item);
            }

            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteAllByQuestionIdAsync(int questionId)
        {
            var items = await dbContext.Answers.Where(x => x.QuestionId == questionId).ToListAsync();
            if (items.Count == 0) return;

            foreach (var item in items) dbContext.Answers.Remove(item);

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Answer>> GetAllAsync()
        {
            return await dbContext.Answers.ToListAsync();
        }

        public async Task<List<Answer>> GetAllByQuestionIdAsync(int questionId)
        {
            return await dbContext.Answers.Where(x => x.QuestionId == questionId).ToListAsync();
        }

        public async Task<List<Answer>> GetAllByIdsAsync(params int[] answersIds)
        {
            return await dbContext.Answers.Where(e => answersIds.Contains(e.Id)).ToListAsync();
        }

        public async Task<Answer> GetByIdAsync(int id)
        {
            return await dbContext.Answers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Answer answer)
        {
            dbContext.Answers.Update(answer);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Answer>> GetAllCorrectByQuestionIdAsync(int questionId)
        {
            return await dbContext.Answers.Where(x => x.QuestionId == questionId && x.IsCorrect).ToListAsync();
        }
    }
}
