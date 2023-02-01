using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;

namespace LX.TestPad.Business.Services
{
    internal class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }


        public async Task<AnswerModel> GetByIdAsync(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("id");

            var item = await _answerRepository.GetByIdAsync(id);

            return Mapper.Map(item);
        }

        public async Task<IReadOnlyCollection<AnswerModel>> GetAllByQuestionIdAsync(int testId)
        {
            if (testId < 1)
                throw new ArgumentOutOfRangeException("testId");

            var items = await _answerRepository.GetAllByQuestionIdAsync(testId);

            return items.Select(Mapper.Map)
                        .ToArray();
        }


        public async Task CreateAsync(AnswerModel testModel)
        {
            var item = Mapper.Map(testModel);

            await _answerRepository.CreateAsync(item);
        }

        public async Task UpdateAsync(AnswerModel testModel)
        {
            var item = Mapper.Map(testModel);

            await _answerRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("id");

            var item = _answerRepository.GetByIdAsync(id);

            await _answerRepository.DeleteAsync(item);
        }

        public async Task DeleteManyAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids) await DeleteAsync(id);
        }

        public async Task DeleteAllByQuestionIdAsync(int questionId)
        {
            if (questionId < 1)
                throw new ArgumentOutOfRangeException("questionId");

            var items = await _answerRepository.GetAllByQuestionIdAsync(questionId);

            foreach (var item in items) await _answerRepository.DeleteAsync(item);
        }
    }
}
