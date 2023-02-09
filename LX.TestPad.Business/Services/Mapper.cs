﻿using LX.TestPad.Business.Models;
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
                TestDuration = entity.TestDuration,
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
        public static ResultModel ResultToModel(Result entity)
        {
            return new ResultModel
            {
                Id = entity.Id,
                Score = entity.Score,
                TestId = entity.TestId,
                UserName = entity.UserName.Substring(0, entity.UserName.IndexOf(' ')),
                UserSurname = entity.UserName.Substring(entity.UserName.IndexOf(' ') + 1),
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
                TestDuration = model.TestDuration
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
                IsCorrect = (bool)model.IsCorrect,
                QuestionId = model.QuestionId,
            };
        }
        public static Result ResultModelToEntity(ResultModel model)
        {
            return new Result
            {
                Id = model.Id,
                UserName = model.UserName +' '+ model.UserSurname,
                Score = model.Score,
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
        public static QuestionWithAnswersModel MapQuestionWithAnswers(Question questionEntity, List<AnswerModel> answerEntities)
        {
            return new QuestionWithAnswersModel
            {
                Id = questionEntity.Id,
                Text = questionEntity.Text,
                Answers = answerEntities,
            };
        }
        public static QuestionWithAnswersModel MapQuestionWithAnswers(Question questionEntity, List<AnswerModelWithoutIsCorrect> answerEntities)
        {
            return new QuestionWithAnswersModel
            {
                Id = questionEntity.Id,
                Text = questionEntity.Text,
                Answers = AnswerModelsWithoutIsCorrectToAnswerModels(answerEntities),
            };
        }
        public static AnswerModelWithoutIsCorrect AnswerToAnswerModelWithoutIsCorrect(Answer entity)
        {
            return new AnswerModelWithoutIsCorrect
            {
                Id = entity.Id,
                Text = entity.Text,
                QuestionId = entity.QuestionId,
            };
        }
        public static List<AnswerModel> AnswerModelsWithoutIsCorrectToAnswerModels(List<AnswerModelWithoutIsCorrect> answerModelsWithoutIs)
        {
            var answerModels = new List<AnswerModel>();
            foreach (AnswerModelWithoutIsCorrect answerModelWithoutIsCorrect in answerModelsWithoutIs)
            {
                answerModels.Add(new AnswerModel{
                    Id = answerModelWithoutIsCorrect.Id,
                    QuestionId = answerModelWithoutIsCorrect.QuestionId,
                    Text = answerModelWithoutIsCorrect.Text,
                });
            }
            return answerModels;
        }
    }
}
