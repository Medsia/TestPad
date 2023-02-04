using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess;
using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.Business.Services
{
    public class ResultAnswerService : IResultAnswerService
    {
        private readonly IResultAnswerRepository _resultAnswerRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        public ResultAnswerService(IResultAnswerRepository resultAnswerRepository, IAnswerRepository answerRepository,
                                    IQuestionRepository questionRepository)
        {
            _resultAnswerRepository = resultAnswerRepository;
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }


        public async Task<QuestionModel> GetQuestionByIdAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _questionRepository.GetByIdAsync(id);

            return Mapper.Map(item);
        }


        public async Task<AnswerModel> GetAnswerByIdAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _answerRepository.GetByIdAsync(id);

            return Mapper.Map(item);
        }


        public async Task<ResultAnswerModel> GetByIdAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _resultAnswerRepository.GetByIdAsync(id);

            return Mapper.Map(item);
        }

        public async Task<List<ResultAnswerModel>> GetAllByResultIdAsync(int resultId)
        {
            ExceptionChecker.SQLKeyIdCheck(resultId);

            var items = await _resultAnswerRepository.GetAllByResultIdAsync(resultId);

            return items.Select(Mapper.Map)
                        .ToList();
        }


        public async Task CreateAsync(int resultId, int answerId)
        {
            ExceptionChecker.SQLKeyIdCheck(resultId);
            ExceptionChecker.SQLKeyIdCheck(answerId);

            var answer = await GetAnswerByIdAsync(answerId);
            var question = await GetQuestionByIdAsync(answer.QuestionId);

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
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _resultAnswerRepository.GetByIdAsync(id);

            await _resultAnswerRepository.DeleteAsync(item);
        }

        public async Task DeleteAllByResultIdAsync(int resultId)
        {
            ExceptionChecker.SQLKeyIdCheck(resultId);

            var items = await _resultAnswerRepository.GetAllByResultIdAsync(resultId);

            foreach (var item in items) await _resultAnswerRepository.DeleteAsync(item);
        }
    }
}
