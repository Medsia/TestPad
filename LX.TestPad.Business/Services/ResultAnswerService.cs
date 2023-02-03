using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess;
using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.Business.Services
{
    public class ResultAnswerService : IResultAnswerService
    {
        private readonly IResultAnswerRepository _resultAnswerRepository;
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;

        public ResultAnswerService(IResultAnswerRepository resultAnswerRepository, IAnswerService answerService,
                                    IQuestionService questionService)
        {
            _resultAnswerRepository = resultAnswerRepository;
            _answerService = answerService;
            _questionService = questionService;
        }


        public async Task<ResultAnswerModel> GetByIdAsync(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("id");

            var item = await _resultAnswerRepository.GetByIdAsync(id);

            return Mapper.Map(item);
        }

        public async Task<List<ResultAnswerModel>> GetAllByResultIdAsync(int resultId)
        {
            if (resultId < 1)
                throw new ArgumentOutOfRangeException("resultId");

            var items = await _resultAnswerRepository.GetAllByResultIdAsync(resultId);

            return items.Select(Mapper.Map)
                        .ToList();
        }


        public async Task CreateAsync(int resultId, int answerId)
        {
            var answer = await _answerService.GetByIdAsync(answerId);
            var question = await _questionService.GetByIdAsync(answer.QuestionId);

            var item = new ResultAnswer
            {
                ResultId = resultId,
                QuestionText = question.Text,
                AnswerText = answer.Text,
                IsCorrect = answer.IsCorrect,
            };

            await _resultAnswerRepository.CreateAsync(item);
        }

        public async Task UpdateAsync(ResultAnswerModel model)
        {
            var item = Mapper.Map(model);

            await _resultAnswerRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("id");

            var item = await _resultAnswerRepository.GetByIdAsync(id);

            await _resultAnswerRepository.DeleteAsync(item);
        }

        public async Task DeleteAllByResultIdAsync(int resultId)
        {
            if (resultId < 1)
                throw new ArgumentOutOfRangeException("resultId");

            var items = await _resultAnswerRepository.GetAllByResultIdAsync(resultId);

            foreach (var item in items) await _resultAnswerRepository.DeleteAsync(item);
        }
    }
}
