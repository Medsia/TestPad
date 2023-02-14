using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess;
using LX.TestPad.DataAccess.Entities;

namespace LX.TestPad.Business.Services
{
    public static class Mapper
    {
        // Mapping from viewmodel to data object
        public static TestModel TestToModel(Test entity)
        {
            return new TestModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                TestDuration = FromSecondsToMinutes(entity.TestDuration),
                IsPublished = entity.IsPublished,
            };
        }
        public static QuestionModel QuestionToModel(Question entity)
        {
            return new QuestionModel
            {
                Id = entity.Id,
                Text = entity.Text,
            };
        }
        public static QuestionModel QuestionWithAnswersToModel(Question entity)
        {
            return new QuestionModel
            {
                Id = entity.Id,
                Text = entity.Text,
                Answers = entity.Answers.Select(Mapper.AnswerToModel)
                        .ToList()
            };
        }

        public static AnswerModel AnswerToModel(Answer entity)
        {
            return new AnswerModel
            {
                Id = entity.Id,
                Text = entity.Text,
                IsCorrect = entity.IsCorrect,
                QuestionId = entity.QuestionId,
            };
        }
        public static ResultIncludeTestModel ResultIncludeTestToModel(Result entity)
        {
            return new ResultIncludeTestModel
            {
                Id = entity.Id,
                Score = entity.Score,
                IsCalculated = entity.IsCalculated,
                TestId = entity.TestId,
                UserName = entity.UserName,
                StartedAt = entity.StartedAt,
                FinishedAt = entity.FinishedAt,
                Test = TestToModel(entity.Test),
            };
        }
        public static ResultModel ResultToModel(Result entity)
        {
            var userName = entity.UserName.Substring(0, entity.UserName.IndexOf(' '));
            var userSurname = entity.UserName.Substring(entity.UserName.IndexOf(' ') + 1);
            return new ResultModel
            {
                Id = entity.Id,
                Score = entity.Score,
                IsCalculated = entity.IsCalculated,
                TestId = entity.TestId,
                UserName = userName,
                UserSurname = userSurname,
                StartedAt = entity.StartedAt,
                FinishedAt = entity.FinishedAt,
            };
        }

        public static ResultAnswerModel ResultAnswerToModel(ResultAnswer entity)
        {
            return new ResultAnswerModel
            {
                Id = entity.Id,
                AnswerText = entity.AnswerText,
                QuestionText = entity.QuestionText,
                ResultId = entity.ResultId,
                QuestionId = entity.Id,
                IsCorrect = entity.IsCorrect,
            };
        }


        // Mapping from data object to viewmodel
        public static Test TestModelToEntity(TestModel model)
        {
            return new Test
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                TestDuration = FromMinutesToSeconds(model.TestDuration),
                IsPublished = model.IsPublished,
            };
        }
        public static Question QuestionModelToEntity(QuestionModel model)
        {
            return new Question
            {
                Id = model.Id,
                Text = model.Text,
            };
        }
        public static Answer AnswerModelToEntity(AnswerModel model)
        {
            return new Answer
            {
                Id = model.Id,
                Text = model.Text,
                IsCorrect = model.IsCorrect,
                QuestionId = model.QuestionId,
            };
        }
        public static Result ResultIncludeTestModelToEntity(ResultIncludeTestModel model)
        {
            return new Result
            {
                Id = model.Id,
                UserName = model.UserName,
                Score = model.Score,
                IsCalculated = model.IsCalculated,
                TestId = model.TestId,
                StartedAt = model.StartedAt,
                FinishedAt = model.FinishedAt,
                Test = TestModelToEntity(model.Test),
            };
        }
        public static Result ResultModelToEntity(ResultModel model)
        {
            return new Result
            {
                Id = model.Id,
                UserName = model.UserName + ' ' + model.UserSurname,
                Score = model.Score,
                IsCalculated = model.IsCalculated,
                TestId = model.TestId,
                StartedAt = model.StartedAt,
                FinishedAt = model.FinishedAt,
            };
        }
        public static ResultAnswer ResultAnswerModelToEntity(ResultAnswerModel model)
        {
            return new ResultAnswer
            {
                Id = model.Id,
                AnswerText = model.AnswerText,
                QuestionText = model.QuestionText,
                ResultId = model.ResultId,
                QuestionId = model.Id,
                IsCorrect = model.IsCorrect,
            };
        }


        // One way mappers
        public static TestQuestionModel TestQuestionToModel(TestQuestion entity)
        {
            return new TestQuestionModel
            {
                Id = entity.Id,
                TestId = entity.TestId,
                QuestionId = entity.QuestionId,
            };
        }
        public static TestQuestionModel TestQuestionWithAnswersAndTestToModel(TestQuestion entity)
        {
            return new TestQuestionModel
            {
                Id = entity.Id,
                TestId = entity.TestId,
                QuestionId = entity.QuestionId,
                Test = TestToModel(entity.Test),
                Question = QuestionWithAnswersToModel(entity.Question),
            };
        }
        public static Question QuestionWithAnswersToQuestionWithAnswersWithoutIsCorrect(Question question)
        {
            return new Question
            {
                Id = question.Id,
                Text = question.Text,
                Answers = question.Answers.Select(answer => new Answer
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Text = answer.Text,
                }).ToList()
            };
        }

        public static int FromMinutesToSeconds(int minutes)
        {
            const int secondsInOneMinute = 60;
            return minutes * secondsInOneMinute;
        }

        public static int FromSecondsToMinutes(int seconds)
        {
            const int secondsInOneMinute = 60;
            return seconds / secondsInOneMinute;
        }
    }
}
