namespace LX.TestPad.Business.Models
{
    public class TestQuestionModel
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }

        public TestModel TestModel { get; set; }
        public QuestionWithAnswersModel QuestionWithAnswersModel {get; set; }
    }
}
