using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
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
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            var items = await _answerRepository.GetAllByQuestionIdAsync(testId);

            return items.Select(Mapper.Map)
                        .ToList();
        }

        public async Task DeleteAllAsnwersByQuestionIdAsync(int questionId)
        {
            if (questionId < 1)
                throw new ArgumentOutOfRangeException("questionId");

            var items = await _answerRepository.GetAllByQuestionIdAsync(questionId);

            foreach (var item in items) await _answerRepository.DeleteAsync(item);
        }



        public async Task<List<TestQuestionModel>> GetAllTestQuestionsByTestIdAsync(int testId)
        {
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            var items = await _testQuestionRepository.GetAllByTestIdAsync(testId);

            return items.Select(Mapper.Map)
                        .ToList();
        }

        public async Task DeleteTestQuestionByQuestionIdAsync(int questionId)
        {
            if (questionId < 1)
                throw new ArgumentOutOfRangeException("questionId");

            var items = await _testQuestionRepository.GetAllByQuestionIdAsync(questionId);

            foreach (var item in items) await _testQuestionRepository.DeleteAsync(item);
        }



        public async Task<QuestionModel> GetByIdAsync(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("id");

            var item = await _questionRepository.GetByIdAsync(id);

            return Mapper.Map(item);
        }

        public async Task<QuestionWithAnswersModel> GetByIdWithAnswersAsync(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("id");

            var question = await _questionRepository.GetByIdAsync(id);
            var answers = await GetAllAnswersByQuestionIdAsync(question.Id);

            return Mapper.Map(question, answers);
        }

        public async Task<List<int>> GetAllQuestionIdsByTestId(int testId)
        {
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            var items = await GetAllTestQuestionsByTestIdAsync(testId);
            var result = items.Select(x => x.QuestionId).ToList();

            return result;
        }


        public async Task CreateAsync(QuestionModel testModel)
        {
            var item = Mapper.Map(testModel);

            await _questionRepository.CreateAsync(item);
        }

        public async Task UpdateAsync(QuestionModel testModel)
        {
            var item = Mapper.Map(testModel);

            await _questionRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteTestQuestionByQuestionIdAsync(id);
            await DeleteAllAsnwersByQuestionIdAsync(id);

            var item = await _questionRepository.GetByIdAsync(id);
            await _questionRepository.DeleteAsync(item);
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            foreach (var id in ids) await DeleteAsync(id);
        }
    }
}
