using LX.TestPad.DataAccess.Entities;
using System.Threading.Tasks;

namespace LX.TestPad.DataAccess.Interfaces
{
    public interface ITestQuestionRepository : IRepository<TestQuestion>
    {
        Task<List<TestQuestion>> GetAllByTestIdAsync(int testId);
        Task<List<TestQuestion>> GetAllByQuestionIdAsync(int QuestionId);
        Task DeleteAllByQuestionIdAsync(int questionId);
    }
}
