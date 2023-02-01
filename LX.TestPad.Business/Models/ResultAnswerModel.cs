using LX.TestPad.DataAccess;

namespace LX.TestPad.Business.Models
{
    public class ResultAnswerModel
    {
        public int Id { get; set; }
        public int ResultId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
    }
}
