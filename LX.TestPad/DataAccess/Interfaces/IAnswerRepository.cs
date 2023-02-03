namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<List<Answer>> GetAllByQuestionIdAsync(int questionId);
        Task<Answer> GetByIdIncludingAsync(int id);
        Task<List<Answer>> GetAllByQuestionIdIncludingAsync(int questionId);
    }
}
