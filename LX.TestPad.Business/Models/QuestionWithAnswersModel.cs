namespace LX.TestPad.Business.Models
{
    public class QuestionWithAnswersModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
