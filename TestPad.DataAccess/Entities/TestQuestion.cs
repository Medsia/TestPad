using System.ComponentModel.DataAnnotations;

namespace LX.TestPad.DataAccess.Entities
{
    public class TestQuestion
    {
        [Key]
        public int Id { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public int Number { get; set; }
        public virtual Test Test { get; set; }
        public virtual Question Question { get; set; }

    }
}