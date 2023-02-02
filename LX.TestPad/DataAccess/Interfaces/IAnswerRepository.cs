namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<IEnumerable<Answer>> GetAllByQuestionIdAsync(int questionId);
        Task<Answer> GetByIdIncludingAsync(int id);
        Task<IEnumerable<Answer>> GetAllByQuestionIdIncludingAsync(int questionId);

    }
}
