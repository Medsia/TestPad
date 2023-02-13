using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess.Entities;
using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.Business.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly IResultAnswerRepository _resultAnswerRepository;
        private readonly ITestQuestionRepository _testQuestionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;

        public ResultService(IResultRepository resultRepository, IResultAnswerRepository resultAnswerRepository,
                                ITestQuestionRepository testQuestionRepository, IAnswerRepository answerRepository,
                                ITestRepository testRepository, IQuestionRepository questionRepository)
        {
            _resultRepository = resultRepository;
            _resultAnswerRepository = resultAnswerRepository;
            _testQuestionRepository = testQuestionRepository;
            _answerRepository = answerRepository;
            _testRepository = testRepository;
            _questionRepository = questionRepository;
        }


        public async Task<ResultModel> GetByIdAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _resultRepository.GetByIdAsync(id);

            return Mapper.ResultToModel(item);
        }

        public async Task<ResultModel> GetByIdAndCalculateAsync(int id)
        {
            ExceptionChecker.SQLKeyIdCheck(id);

            var item = await _resultRepository.GetByIdAsync(id);

            return await CheckIfCalculated(item);
        }

        public async Task<List<ResultModel>> GetAllAsync()
        {
            var items = await _resultRepository.GetAllAsync();

            return items.Select(Mapper.ResultToModel).ToList();
        }

        public async Task<List<ResultWithTestModel>> GetAllIncludeTestAsync()
        {
            var items = await _resultRepository.GetAllIncludeTestAsync();

            return items.Select(Mapper.ResultWithTestToModel).ToList();
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


        private async Task<bool> IsAnyIncorrectResultAnswerAsync(List<ResultAnswer> resultAnswers, Question question)
        {
            throw new NotImplementedException();
        }
        private async Task<int> CountAllCorrectResultAnswersByQuestionIdAsync(List<ResultAnswer> resultAnswers, Question question)
        {
            throw new NotImplementedException();
        }
        private async Task<double> CalculateScore(Result result)
        {
            double score = 0;

            var resultAnswers = await _resultAnswerRepository.GetAllByResultIdAsync(result.Id);
            var answers = await _answerRepository.GetAllAsync();
            var questions = (await _testQuestionRepository.GetAllByTestIdIncludeQuestionsAsync(result.TestId)).Select(x => x.Question);

            foreach (var question in questions)
            {
                if (await _resultAnswerRepository.IsAnyIncorrectAsync(result.Id, question.Id)) continue;

                int totalCorrectAnswersCount = (answers.Where(x => x.QuestionId == question.Id && x.IsCorrect)).Count();
                int correctAnswersCount = await _resultAnswerRepository.CountAllCorrectByQuestionIdAsync(result.Id, question.Id);

                score += (double)correctAnswersCount / totalCorrectAnswersCount;
            }
            score /= questions.Count();

            return Math.Round(score, 3);
        }

        private async Task<DateTime> CalculateFinishTime(Result result)
        {
            var finishedAt = DateTime.Now.ToUniversalTime();
            var testDuration = (await _testRepository.GetByIdAsync(result.TestId)).TestDuration;

            if ((finishedAt - result.StartedAt).TotalSeconds >= testDuration)
            {
                finishedAt = result.StartedAt.AddSeconds(testDuration);
            }

            return finishedAt;
        }

        public async Task<ResultModel> CheckIfCalculated(Result result)
        {
            if (!result.IsCalculated)
            {
                result.Score = await CalculateScore(result);
                result.FinishedAt = await CalculateFinishTime(result);
                result.IsCalculated = true;

                await _resultRepository.UpdateAsync(result);
            }

            return Mapper.ResultToModel(result);
        }
    }
}
