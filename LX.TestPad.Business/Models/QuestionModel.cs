namespace LX.TestPad.Business.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Text { get; set; }
        public virtual List<AnswerModel> Answers { get; set; }

    }
}
