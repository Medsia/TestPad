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


        public async Task<ResultAnswerModel> GetByIdAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _resultAnswerRepository.GetByIdAsync(id);

            return Mapper.ResultAnswerToModel(item);
        }

        public async Task<List<ResultAnswerModel>> GetAllByResultIdAsync(int resultId)
        {
            ExceptionChecker.SQLKeyIdCheck(resultId);

            var items = await _resultAnswerRepository.GetAllByResultIdAsync(resultId);

            return items.Select(Mapper.ResultAnswerToModel)
                        .ToList();
        }


        public async Task<ResultAnswerModel> CreateAsync(int resultId, int answerId)
        {
            ExceptionChecker.SQLKeyIdCheck(resultId);
            ExceptionChecker.SQLKeyIdCheck(answerId);

            var answer = await _answerRepository.GetByIdAsync(answerId);
            var question = await _questionRepository.GetByIdAsync(answer.QuestionId);

            var item = new ResultAnswer
            {
                ResultId = resultId,
                QuestionText = question.Text,
                AnswerText = answer.Text,
                IsCorrect = answer.IsCorrect,
            };

            item = await _resultAnswerRepository.CreateAsync(item);

            return Mapper.ResultAnswerToModel(item);
        }
        public async Task AddUserResultAnswersAsync(int resultId, params int[] answersId)
        {
            ExceptionChecker.SQLKeyIdCheck(resultId);
            foreach (var answerId in answersId)
            {
                ExceptionChecker.SQLKeyIdCheck(answerId);
            }

            var answers = await _answerRepository.GetAllByIdsAsync(answersId);
            var question = await _questionRepository.GetByIdAsync(answers[0].QuestionId);

            var items = new ResultAnswer[answers.Count];
            for(int i = 0; i < items.Length; i++) 
            {
                if (question.Id != answers[i].QuestionId)
                    throw new ArgumentException("Answer cannot be matched with question.", "answers[i].QuestionId");
                items[i] = (new ResultAnswer
                {
                    ResultId = resultId,
                    QuestionText = question.Text,
                    AnswerText = answers[i].Text,
                    IsCorrect = answers[i].IsCorrect,
                });
            }

            await _resultAnswerRepository.CreateRangeAsync(items);
        }
        public async Task<ResultAnswerModel> CreateAsync(ResultAnswerModel model)
        {
            var item = Mapper.ResultAnswerModelToEntity(model);

            item = await _resultAnswerRepository.CreateAsync(item);

            return Mapper.ResultAnswerToModel(item);
        }

        public async Task UpdateAsync(ResultAnswerModel resultAnswerModel)
        {
            var item = Mapper.ResultAnswerModelToEntity(resultAnswerModel);

            await _resultAnswerRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            await _resultAnswerRepository.DeleteAsync(id);
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            ExceptionChecker.ListOfSQLKeyIdsCheck(ids);

            await _resultAnswerRepository.DeleteManyAsync(ids);
        }

        public async Task DeleteAllByResultIdAsync(int resultId)
        {
            ExceptionChecker.SQLKeyIdCheck(resultId);

            await _resultAnswerRepository.DeleteAllByResultIdAsync(resultId);
        }
    }
}
