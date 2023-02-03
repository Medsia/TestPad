using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerService _answerService;
        private readonly ITestQuestionService _testQuestionService;

        public QuestionService(IQuestionRepository questionRepository, IAnswerService answerService,
                                ITestQuestionService testQuestionService)
        {
            _questionRepository = questionRepository;
            _answerService = answerService;
            _testQuestionService = testQuestionService;
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
            var answers = await _answerService.GetAllByQuestionIdAsync(question.Id);

            return Mapper.Map(question, answers);
        }

        public async Task<List<int>> GetAllQuestionIdsByTestId(int testId)
        {
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            var items = await _testQuestionService.GetAllByTestIdAsync(testId);
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
            await _testQuestionService.DeleteByQuestionIdAsync(id);
            await _answerService.DeleteAllByQuestionIdAsync(id);

            var item = await _questionRepository.GetByIdAsync(id);
            await _questionRepository.DeleteAsync(item);
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            foreach (var id in ids) await DeleteAsync(id);
        }
    }
}
