namespace LX.TestPad.Business.Models
{
    public class ResultAnswerModel
    {
        public int Id { get; set; }
        public int ResultId { get; set; }
        public int? QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
