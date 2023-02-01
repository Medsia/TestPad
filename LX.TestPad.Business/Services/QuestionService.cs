using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;

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

            var item = _questionRepository.GetByIdAsync(id);
            await _questionRepository.DeleteAsync(item);
        }

        public async Task DeleteManyAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids) await DeleteAsync(id);
        }
    }
}
