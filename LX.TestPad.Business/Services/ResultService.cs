using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.Business.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly IResultAnswerRepository _resultAnswerRepository;
        private readonly ITestQuestionRepository _testQuestionRepository;
        private readonly IAnswerRepository _answerRepository;


        public ResultService(IResultRepository resultRepository, IResultAnswerRepository resultAnswerRepository,
                                ITestQuestionRepository testQuestionRepository, IAnswerRepository answerRepository)
        {
            _resultRepository = resultRepository;
            _resultAnswerRepository = resultAnswerRepository;
            _testQuestionRepository = testQuestionRepository;
            _answerRepository = answerRepository;
        }


        public async Task<ResultModel> GetByIdAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _resultRepository.GetByIdAsync(id);

            return Mapper.ResultToModel(item);
        }

        public async Task<List<ResultModel>> GetAllByTestIdAsync(int testId)
        {
            ExceptionChecker.SQLKeyIdCheck(testId);

            var items = await _resultRepository.GetAllByTestIdAsync(testId);

            return items.Select(Mapper.ResultToModel)
                        .ToList();
        }

        public async Task<ResultModel> CreateAsync(ResultModel resultModel)
        {
            var item = Mapper.ResultModelToEntity(resultModel);

            item = await _resultRepository.CreateAsync(item);

            return Mapper.ResultToModel(item);
        }

        public async Task UpdateAsync(ResultModel resultModel)
        {
            var item = Mapper.ResultModelToEntity(resultModel);

            await _resultRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            await _resultRepository.DeleteAsync(id);
        }

        public async Task DeleteManyAsync(List<int> ids)
        {
            ExceptionChecker.ListOfSQLKeyIdsCheck(ids);

            await _resultRepository.DeleteManyAsync(ids);
        }

        public async Task<int> CalculateScore(int resultId)
        {
            ExceptionChecker.SQLKeyIdCheck(resultId);

            int score = 0;

            var result = await _resultRepository.GetByIdAsync(resultId);
            var correctResultAnswersCount = (await _resultAnswerRepository.GetAllCorrectByResultIdAsync(resultId)).Count;

            var questions = await _testQuestionRepository.GetAllByTestIdAsync(result.TestId);

            int totalCorrectAnswersCount = 0;
            foreach (var question in questions)
            {
                totalCorrectAnswersCount += (await _answerRepository.GetAllCorrectByQuestionIdAsync(question.Id)).Count;
            }

            score = correctResultAnswersCount * 100 / totalCorrectAnswersCount;

            result.Score = score;
            await _resultRepository.UpdateAsync(result);

            return score;
        }
    }
}
