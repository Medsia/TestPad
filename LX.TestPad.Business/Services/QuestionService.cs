using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;
using LX.TestPad.DataAccess.Repositories;

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


        public async Task<List<AnswerModel>> GetAllAnswersByQuestionIdAsync(int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);

            var items = await _answerRepository.GetAllByQuestionIdAsync(testId);

            return items.Select(Mapper.AnswerToModel)
                        .ToList();
        }
        public async Task DeleteAllAsnwersByQuestionIdAsync(int questionId)
        {
            ExceptionChecker.SQLKeyIdCheck(questionId);

            await _answerRepository.DeleteAllByQuestionIdAsync(questionId);
        }
        public async Task DeleteTestQuestionsByQuestionIdAsync(int questionId)
        {
            ExceptionChecker.SQLKeyIdCheck(questionId);

            await _testQuestionRepository.DeleteAllByQuestionIdAsync(questionId);
        }



        public async Task<QuestionModel> GetByIdAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _questionRepository.GetByIdAsync(id);

            return Mapper.QuestionToModel(item);
        }

        public async Task<QuestionWithAnswersModel> GetByIdWithAnswersAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var question = await _questionRepository.GetByIdAsync(id);
            var answers = await GetAllAnswersByQuestionIdAsync(question.Id);

            return Mapper.QuestionWithAnswers(question, answers);
        }

        public async Task CreateAsync(QuestionModel testModel)
        {
            var item = Mapper.QuestionModelToEntity(testModel);

            await _questionRepository.CreateAsync(item);
        }

        public async Task UpdateAsync(QuestionModel testModel)
        {
            var item = Mapper.QuestionModelToEntity(testModel);

            await _questionRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteTestQuestionsByQuestionIdAsync(id);
            await DeleteAllAsnwersByQuestionIdAsync(id);

            await _questionRepository.DeleteAsync(id);
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            await _questionRepository.DeleteManyAsync(ids);
        }
    }
}
