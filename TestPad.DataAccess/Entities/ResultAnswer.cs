﻿using System.ComponentModel.DataAnnotations;

namespace LX.TestPad.DataAccess.Entities
{
    public class ResultAnswer
    {

        [Key]
        public int Id { get; set; }
        public int ResultId { get; set; }
        public int? QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public virtual Result Result { get; set; }
    }
}
