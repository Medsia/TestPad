namespace LX.TestPad.Business.Models
{
    public class TestQuestionModel
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public TestModel Test { get; set; }
        public QuestionModel Question { get; set; }
    }
}
