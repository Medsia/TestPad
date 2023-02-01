using LX.TestPad.Business.Services;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LX.TestPad.Business.Interfaces
{
    public interface ITestQuestionService
    {
        Task<IEnumerable<QuestionModel>> GetAllQuestionsByTestIdAsync(int testId);
        Task<IEnumerable<QuestionModel>> GetAllTestsByQuestionIdAsync(int questionId);
    }
}
