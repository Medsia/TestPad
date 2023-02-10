namespace LX.TestPad.Business.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        public string Text { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
