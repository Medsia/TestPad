namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question> GetByIdAsync(int id);
        Task<IEnumerable<Question>> GetAllAsync();
        Task CreateAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(Question question);
    }
}
