namespace LX.TestPad.Business.Models
{
    public class UserAnswerModel
    {
        public int ResultId { get; set; }
        public int TestId { get; set; }
        public int[] AnswersIds { get; set; }
    }
}
