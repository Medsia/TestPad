using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess;

namespace LX.TestPad.Business.Services
{
    public static class Mapper
    {
        // Mapping from viewmodel to data object
        public static TestModel Map(Test entity)
        {
            return new TestModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                TestDuration = entity.TestDuration,
            };
        }
        public static QuestionModel Map(Question entity)
        {
            return new QuestionModel
            {
                Id = entity.Id,
                Text = entity.Text,
            };
        }
        public static AnswerModel Map(Answer entity)
        {
            return new AnswerModel
            {
                Id = entity.Id,
                Text = entity.Text,
                IsCorrect = entity.IsCorrect,
                QuestionId = entity.QuestionId,
            };
        }
        public static ResultModel Map(Result entity)
        {
            return new ResultModel
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Score = entity.Score,
                TestId = entity.TestId,
                StartedAt = entity.StartedAt,
                FinishedAt = entity.FinishedAt,
            };
        }
        public static ResultAnswerModel Map(ResultAnswer entity)
        {
            return new ResultAnswerModel
            {
                Id = entity.Id,
                AnswerText = entity.AnswerText,
                QuestionText = entity.QuestionText,
                ResultId = entity.ResultId,
                IsCorrect = entity.IsCorrect,
            };
        }


        // Mapping from data object to viewmodel
        public static Test Map(TestModel model)
        {
            return new Test
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                TestDuration = model.TestDuration
            };
        }
        public static Question Map(QuestionModel model)
        {
            return new Question
            {
                Id = model.Id,
                Text = model.Text,
            };
        }
        public static Answer Map(AnswerModel model)
        {
            return new Answer
            {
                Id = model.Id,
                Text = model.Text,
                IsCorrect = model.IsCorrect,
                QuestionId = model.QuestionId,
            };
        }
        public static Result Map(ResultModel model)
        {
            return new Result
            {
                Id = model.Id,
                UserName = model.UserName,
                Score = model.Score,
                TestId = model.TestId,
                StartedAt = model.StartedAt,
                FinishedAt = model.FinishedAt,
            };
        }
        public static ResultAnswer Map(ResultAnswerModel model)
        {
            return new ResultAnswer
            {
                Id = model.Id,
                AnswerText = model.AnswerText,
                QuestionText = model.QuestionText,
                ResultId = model.ResultId,
                IsCorrect = model.IsCorrect,
            };
        }


        // One way mappers
        public static TestQuestionModel Map(TestQuestion entity)
        {
            return new TestQuestionModel
            {
                Id = entity.Id,
                TestId = entity.TestId,
                QuestionId = entity.QuestionId,
            };
        }
        public static QuestionWithAnswersModel Map(Question questionEntity, List<AnswerModel> answerEntities)
        {
            return new QuestionWithAnswersModel
            {
                Id = questionEntity.Id,
                Text = questionEntity.Text,
                Answers = answerEntities,
            };
        }
    }
}
