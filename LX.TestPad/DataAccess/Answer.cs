using System.ComponentModel.DataAnnotations;

namespace LX.TestPad.DataAccess
{
    public class Answer
    {

        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }

        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; }
    }
}
