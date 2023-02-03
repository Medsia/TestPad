using System.ComponentModel.DataAnnotations;

namespace LX.TestPad.DataAccess.Entities
{
    public class Question
    {

        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
