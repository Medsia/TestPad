using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;

namespace LX.TestPad.Business.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly IResultAnswerRepository _resultAnswerRepository;
        private readonly ITestQuestionRepository _testQuestionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly ITestRepository _testRepository;


        public ResultService(IResultRepository resultRepository, IResultAnswerRepository resultAnswerRepository,
                                ITestQuestionRepository testQuestionRepository, IAnswerRepository answerRepository,
                                ITestRepository testRepository)
        {
            _resultRepository = resultRepository;
            _resultAnswerRepository = resultAnswerRepository;
            _testQuestionRepository = testQuestionRepository;
            _answerRepository = answerRepository;
            _testRepository = testRepository;
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

        public async Task<double> CalculateScore(int resultId)
        {
            ExceptionChecker.SQLKeyIdCheck(resultId);

            double score = 0;

            var result = await _resultRepository.GetByIdAsync(resultId);
            var testQuestions = await _testQuestionRepository.GetAllByTestIdAsync(result.TestId);

            foreach (var testQuestion in testQuestions)
            {
                if (await _resultAnswerRepository.IsAnyIncorrectAsync(resultId, testQuestion.Id)) continue;

                int totalCorrectAnswersCount = (await _answerRepository.GetAllCorrectByQuestionIdAsync(testQuestion.QuestionId)).Count;
                int correctAnswersCount = await _resultAnswerRepository.CountAllCorrectByQuestionIdAsync(resultId, testQuestion.QuestionId);
                score += (double)correctAnswersCount / totalCorrectAnswersCount;
            }
            score /= testQuestions.Count;

            result.Score = Math.Round(score, 3);
            await _resultRepository.UpdateAsync(result);

            return score;
        }

        public async Task<DateTime> CalculateFinishTime(int resultId)
        {
            ExceptionChecker.SQLKeyIdCheck(resultId);

            var finishedAt = DateTime.Now.ToUniversalTime();

            var result = await _resultRepository.GetByIdAsync(resultId);
            var testDuration = (await _testRepository.GetByIdAsync(result.TestId)).TestDuration;

            var test = (finishedAt - result.StartedAt).TotalSeconds;
            if (test >= testDuration)
            {
                finishedAt = result.StartedAt;
                finishedAt = finishedAt.AddSeconds(testDuration);
            }

            result.FinishedAt = finishedAt;

            await _resultRepository.UpdateAsync(result);

            return finishedAt;
        }
    }
}
