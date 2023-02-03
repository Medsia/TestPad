namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<List<Answer>> GetAllByQuestionIdAsync(int questionId);
    }
}
