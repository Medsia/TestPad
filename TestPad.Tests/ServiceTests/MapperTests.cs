using LX.TestPad.Business.Models;
using LX.TestPad.Business.Services;
using LX.TestPad.DataAccess;
using LX.TestPad.DataAccess.Entities;
using System;

namespace LX.TestPad.Tests.ServiceTests
{
    public class MapperTests
    {
        // Entity : Model pairs for testing
        static Test testEntity { get; } = new Test { Id = 11, Name = "Fantasies", Description = "They are deep and also dark", TestDuration = 300 };
        static TestModel testModel { get; } = new TestModel { Id = 11, Name = "Fantasies", Description = "They are deep and also dark", TestDuration = 300 };

        static Question questionEntity { get; } = new Question { Id = 3, Text = "Some question text" };
        static QuestionModel questionModel { get; } = new QuestionModel { Id = 3, Text = "Some question text" };

        static TestQuestion testQuestionEntity { get; } = new TestQuestion { Id = 12, TestId = 11, QuestionId = 3 };
        static TestQuestionModel testQuestionModel { get; } = new TestQuestionModel { Id = 12, TestId = 11, QuestionId = 3 };

        static Answer answerEntity { get; } = new Answer { Id = 13, QuestionId = 3, Text = "Some answer text", IsCorrect = false };
        static AnswerModel answerModel { get; } = new AnswerModel { Id = 13, QuestionId = 3, Text = "Some answer text", IsCorrect = false };

        static DateTime dateTimeStarted = DateTime.Now;
        static DateTime dateTimeFinished = DateTime.Now.AddMinutes(10.0);
        static Result resultEntity { get; } = new Result
        {
            Id = 1,
            TestId = 11,
            UserName = "Chel Chelov",
            StartedAt = dateTimeStarted,
            FinishedAt = dateTimeFinished,
            Score = 22.5
        };
        static ResultModel resultModel { get; } = new ResultModel
        {
            Id = 1,
            TestId = 11,
            UserName = "Chel",
            UserSurname = "Chelov",
            StartedAt = dateTimeStarted,
            FinishedAt = dateTimeFinished,
            Score = 22.5
        };

        static ResultAnswer resultAnswerEntity { get; } = new ResultAnswer
        {
            Id = 8,
            AnswerText = answerEntity.Text,
            QuestionText = questionEntity.Text,
            ResultId = resultEntity.Id
        };
        static ResultAnswerModel resultAnswerModel { get; } = new ResultAnswerModel
        {
            Id = 8,
            AnswerText = answerModel.Text,
            QuestionText = questionModel.Text,
            ResultId = resultModel.Id
        };


        [Fact]
        public void TestModel_MappedFromTest_IsCorrect()
        {
            var actualModel = Mapper.TestToModel(testEntity);

            Assert.Equal(testModel.Id, actualModel.Id);
            Assert.Equal(testModel.Name, actualModel.Name);
            Assert.Equal(testModel.Description, actualModel.Description);
            Assert.Equal(testModel.TestDuration, actualModel.TestDuration);
        }

        [Fact]
        public void QuestionModel_MappedFromQuestion_IsCorrect()
        {
            var actualModel = Mapper.QuestionToModel(questionEntity);

            Assert.Equal(questionModel.Id, actualModel.Id);
            Assert.Equal(questionModel.Text, actualModel.Text);
        }

        [Fact]
        public void TestQuestionModel_MappedFromTestQuestion_IsCorrect()
        {
            var actualModel = Mapper.TestQuestionToModel(testQuestionEntity);

            Assert.Equal(testQuestionModel.Id, actualModel.Id);
            Assert.Equal(testQuestionModel.TestId, actualModel.TestId);
            Assert.Equal(testQuestionModel.QuestionId, actualModel.QuestionId);
        }

        [Fact]
        public void AnswerModel_MappedFromAnswer_IsCorrect()
        {
            var actualModel = Mapper.AnswerToModel(answerEntity);

            Assert.Equal(answerModel.Id, actualModel.Id);
            Assert.Equal(answerModel.QuestionId, actualModel.QuestionId);
            Assert.Equal(answerModel.Text, actualModel.Text);
            Assert.Equal(answerModel.IsCorrect, actualModel.IsCorrect);
        }

        [Fact]
        public void ResultModel_MappedFromResult_IsCorrect()
        {
            var actualModel = Mapper.ResultToModel(resultEntity);

            Assert.Equal(resultModel.Id, actualModel.Id);
            Assert.Equal(resultModel.TestId, actualModel.TestId);
            Assert.Equal(resultModel.UserName, actualModel.UserName);
            Assert.Equal(resultModel.UserSurname, actualModel.UserSurname);
            Assert.Equal(resultModel.Score, actualModel.Score);
            Assert.Equal(resultModel.StartedAt, actualModel.StartedAt);
            Assert.Equal(resultModel.FinishedAt, actualModel.FinishedAt);
        }

        [Fact]
        public void ResultAnswerModel_MappedFromResultAnswer_IsCorrect()
        {
            var actualModel = Mapper.ResultAnswerToModel(resultAnswerEntity);

            Assert.Equal(resultAnswerModel.Id, actualModel.Id);
            Assert.Equal(resultAnswerModel.ResultId, actualModel.ResultId);
            Assert.Equal(resultAnswerModel.QuestionText, actualModel.QuestionText);
            Assert.Equal(resultAnswerModel.AnswerText, actualModel.AnswerText);
            Assert.Equal(resultAnswerModel.IsCorrect, actualModel.IsCorrect);
        }

        [Fact]
        public void Test_MappedFromTestModel_IsCorrect()
        {
            var actualEntity = Mapper.TestModelToEntity(testModel);

            Assert.Equal(testEntity.Id, actualEntity.Id);
            Assert.Equal(testEntity.Name, actualEntity.Name);
            Assert.Equal(testEntity.Description, actualEntity.Description);
            Assert.Equal(testEntity.TestDuration, actualEntity.TestDuration);
        }

        [Fact]
        public void Question_MappedFromQuestionModel_IsCorrect()
        {
            var actualEntity = Mapper.QuestionModelToEntity(questionModel);

            Assert.Equal(questionEntity.Id, actualEntity.Id);
            Assert.Equal(questionEntity.Text, actualEntity.Text);
        }

        [Fact]
        public void Answer_MappedFromAnswerModel_IsCorrect()
        {
            var actualEntity = Mapper.AnswerModelToEntity(answerModel);

            Assert.Equal(answerEntity.Id, actualEntity.Id);
            Assert.Equal(answerEntity.QuestionId, actualEntity.QuestionId);
            Assert.Equal(answerEntity.Text, actualEntity.Text);
            Assert.Equal(answerEntity.IsCorrect, actualEntity.IsCorrect);
        }

        [Fact]
        public void Result_MappedFromResultModel_IsCorrect()
        {
            var actualEntity = Mapper.ResultModelToEntity(resultModel);

            Assert.Equal(resultEntity.Id, actualEntity.Id);
            Assert.Equal(resultEntity.TestId, actualEntity.TestId);
            Assert.Equal(resultEntity.UserName, actualEntity.UserName);
            Assert.Equal(resultEntity.Score, actualEntity.Score);
            Assert.Equal(resultEntity.StartedAt, actualEntity.StartedAt);
            Assert.Equal(resultEntity.FinishedAt, actualEntity.FinishedAt);
        }

        [Fact]
        public void ResultAnswer_MappedFromeResultAnswerModel_IsCorrect()
        {
            var actualEntity = Mapper.ResultAnswerModelToEntity(resultAnswerModel);

            Assert.Equal(resultAnswerEntity.Id, actualEntity.Id);
            Assert.Equal(resultAnswerEntity.ResultId, actualEntity.ResultId);
            Assert.Equal(resultAnswerEntity.QuestionText, actualEntity.QuestionText);
            Assert.Equal(resultAnswerEntity.AnswerText, actualEntity.AnswerText);
            Assert.Equal(resultAnswerEntity.IsCorrect, actualEntity.IsCorrect);
        }
    }
}