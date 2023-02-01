using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class ResultAnswerRepository : IResultAnswerRepository
    {
        private DataContext db = new DataContext();
        public async Task CreateAsync(ResultAnswer resultAnswer)
        {
            await db.ResultAnswers.AddAsync(resultAnswer);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(ResultAnswer resultAnswer)
        {
            db.ResultAnswers.Remove(resultAnswer);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ResultAnswer>> GetAllByResultIdAsync(int resultId)
        {
            return await db.ResultAnswers.Where(x => x.ResultId == resultId).ToListAsync();
        }

        public async Task<ResultAnswer> GetByIdAsync(int id)
        {
            return await db.ResultAnswers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(ResultAnswer resultAnswer)
        {
            db.Entry(resultAnswer).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
