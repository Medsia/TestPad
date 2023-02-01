namespace LX.TestPad.DataAccess.Interfaces
{
    public interface IAnswerRepository
    {
        Task<Answer> GetByIdAsync(int id);
        Task<IEnumerable<Answer>> GetAllAsync();
        Task CreateAsync(Answer answer);
        Task UpdateAsync(Answer answer);
        Task DeleteAsync(Answer answer);
    }
}
