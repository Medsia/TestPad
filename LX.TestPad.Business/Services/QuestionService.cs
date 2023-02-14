using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly ITestQuestionRepository _testQuestionRepository;
        public QuestionService(IQuestionRepository questionRepository, IAnswerRepository answerRepository, 
            ITestQuestionRepository testQuestionRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _testQuestionRepository = testQuestionRepository;
        }


        public async Task<List<AnswerModel>> GetAllAnswersByQuestionIdAsync(int questionId)
        {
            ExceptionChecker.SQLKeyIdCheck(questionId);

            var items = await _answerRepository.GetAllByQuestionIdAsync(questionId);

            return items.Select(Mapper.AnswerToModel)
                        .ToList();
        }


        public async Task<QuestionModel> GetByIdAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _questionRepository.GetByIdAsync(id);

            return Mapper.QuestionToModel(item);
        }

        public async Task<List<QuestionModel>> GetAllAsync()
        {
            var item = await _questionRepository.GetAllAsync();

            return item.Select(Mapper.QuestionToModel)
                       .ToList();
        }

        public async Task<QuestionModel> CreateAsync(QuestionModel questionModel)
        {
            var item = Mapper.QuestionModelToEntity(questionModel);

            item = await _questionRepository.CreateAsync(item);

            return Mapper.QuestionToModel(item);
        }

        public async Task UpdateAsync(QuestionModel questionModel)
        {
            var item = Mapper.QuestionModelToEntity(questionModel);

            await _questionRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            await _questionRepository.DeleteAsync(id);
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            ExceptionChecker.ListOfSQLKeyIdsCheck(ids);

            await _questionRepository.DeleteManyAsync(ids);
        }
    }
}
