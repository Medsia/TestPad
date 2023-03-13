using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.Business.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }


        public async Task<AnswerModel> GetByIdAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _answerRepository.GetByIdAsync(id);

            return Mapper.AnswerToModel(item);
        }

        public async Task<List<AnswerModel>> GetAllByQuestionIdAsync(int questionId)
        {
            ExceptionChecker.SQLKeyIdCheck(questionId);

            var items = await _answerRepository.GetAllByQuestionIdAsync(questionId);

            return items.Select(Mapper.AnswerToModel)
                        .ToList();
        }

        public async Task<AnswerModel> CreateAsync(AnswerModel testModel)
        {
            var item = Mapper.AnswerModelToEntity(testModel);

            item = await _answerRepository.CreateAsync(item);

            return Mapper.AnswerToModel(item);
        }

        public async Task UpdateAsync(AnswerModel testModel)
        {
            var item = Mapper.AnswerModelToEntity(testModel);

            await _answerRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            await _answerRepository.DeleteAsync(id);
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            ExceptionChecker.ListOfSQLKeyIdsCheck(ids);

            await _answerRepository.DeleteManyAsync(ids);
        }

        public async Task DeleteAllByQuestionIdAsync(int questionId)
        {
            ExceptionChecker.SQLKeyIdCheck(questionId);

            await _answerRepository.DeleteAllByQuestionIdAsync(questionId);
        }
    }
}
