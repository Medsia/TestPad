using LX.TestPad.Business.Models;
using LX.TestPad.Business.Services;
using LX.TestPad.DataAccess;

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

        static Result resultEntity { get; } = new Result
        {
            Id = 1,
            TestId = 11,
            UserName = "Chel Chelov",
            FinishedAt = DateTime.UtcNow,
            StartedAt = DateTime.UtcNow,
            Score = 22.5
        };
        static ResultModel resultModel { get; } = new ResultModel
        {
            Id = 1,
            TestId = 11,
            UserName = "Chel Chelov",
            FinishedAt = DateTime.UtcNow,
            StartedAt = DateTime.UtcNow,
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
            var actualModel = Mapper.Map(testEntity);

            Assert.Equal(testModel, actualModel);
        }

        [Fact]
        public void QuestionModel_MappedFromQuestion_IsCorrect()
        {
            var actualModel = Mapper.Map(questionEntity);

            Assert.Equal(questionModel, actualModel);
        }

        [Fact]
        public void TestQuestionModel_MappedFromTestQuestion_IsCorrect()
        {
            var actualModel = Mapper.Map(testQuestionEntity);

            Assert.Equal(testQuestionModel, actualModel);
        }

        [Fact]
        public void AnswerModel_MappedFromAnswer_IsCorrect()
        {
            var actualModel = Mapper.Map(answerEntity);

            Assert.Equal(answerModel, actualModel);
        }

        [Fact]
        public void ResultModel_MappedFromResult_IsCorrect()
        {
            var actualModel = Mapper.Map(resultEntity);

            Assert.Equal(resultModel, actualModel);
        }

        [Fact]
        public void ResultAnswerModel_MappedFromResultAnswer_IsCorrect()
        {
            var actualModel = Mapper.Map(resultAnswerEntity);

            Assert.Equal(resultAnswerModel, actualModel);
        }



        [Fact]
        public void Test_MappedFromTestModel_IsCorrect()
        {
            var actualEntity = Mapper.Map(testModel);

            Assert.Equal(testEntity, actualEntity);
        }

        [Fact]
        public void Question_MappedFromQuestionModel_IsCorrect()
        {
            var actualEntity = Mapper.Map(questionModel);

            Assert.Equal(questionEntity, actualEntity);
        }

        [Fact]
        public void TestQuestion_MappedFromTestQuestionModel_IsCorrect()
        {
            var actualEntity = Mapper.Map(testQuestionModel);

            Assert.Equal(testQuestionEntity, actualEntity);
        }

        [Fact]
        public void Answer_MappedFromAnswerModel_IsCorrect()
        {
            var actualEntity = Mapper.Map(answerModel);

            Assert.Equal(answerEntity, actualEntity);
        }

        [Fact]
        public void Result_MappedFromResultModel_IsCorrect()
        {
            var actualEntity = Mapper.Map(resultModel);

            Assert.Equal(resultEntity, actualEntity);
        }

        [Fact]
        public void ResultAnswer_MappedFromeResultAnswerModel_IsCorrect()
        {
            var actualEntity = Mapper.Map(resultAnswerModel);

            Assert.Equal(resultAnswerEntity, actualEntity);
        }


        [Fact]
        public void QuestionWithAnswers_MappedFromQuestionEntityAndListOfAnswerEntities_IsCorrect()
        {
            var testList = new List<Answer> { answerEntity };
            var actualResult = Mapper.Map(questionEntity, testList);

            var expectedAnswers = new List<AnswerModel> { answerModel };
            var expectedResult = new QuestionWithAnswersModel { Id = questionEntity.Id, Text = questionEntity.Text, Answers = expectedAnswers };

            Assert.Equal(expectedResult, actualResult);
        }
    }
}