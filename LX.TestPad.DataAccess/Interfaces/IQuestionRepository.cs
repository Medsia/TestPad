using LX.TestPad.DataAccess.Entities;

namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<List<Question>> GetAllUnusedAsync();
        Task<Question> CreateBasicQuestionAsync();
    }
}
