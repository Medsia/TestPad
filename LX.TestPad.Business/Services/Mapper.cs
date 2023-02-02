using LX.TestPad.Business.Models;
using LX.TestPad.DataAccess;

namespace LX.TestPad.Business.Services
{
    public static class Mapper
    {
        // Mapping from viewmodel to data object
        public static TestModel Map(Test obj)
        {
            return new TestModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                TestDuration = obj.TestDuration,
            };
        }
        public static TestQuestionModel Map(TestQuestion obj)
        {
            return new TestQuestionModel
            {
                Id = obj.Id,
                TestId = obj.TestId,
                QuestionId = obj.QuestionId,
            };
        }
        public static QuestionModel Map(Question obj)
        {
            return new QuestionModel
            {
                Id = obj.Id,
                Text = obj.Text,
            };
        }
        public static AnswerModel Map(Answer obj)
        {
            return new AnswerModel
            {
                Id = obj.Id,
                Text = obj.Text,
                IsCorrect = obj.IsCorrect,
                QuestionId = obj.QuestionId,
            };
        }
        public static ResultModel Map(Result obj)
        {
            return new ResultModel
            {
                Id = obj.Id,
                UserName = obj.UserName,
                Score = obj.Score,
                TestId = obj.TestId,
            };
        }
        public static ResultAnswerModel Map(ResultAnswer obj)
        {
            return new ResultAnswerModel
            {
                Id = obj.Id,
                AnswerText = obj.AnswerText,
                QuestionText = obj.QuestionText,
                ResultId = obj.ResultId,
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
        public static TestQuestion Map(TestQuestionModel model)
        {
            return new TestQuestion
            {
                Id = model.Id,
                TestId = model.TestId,
                QuestionId = model.QuestionId,
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
            };
        }
    }
}
