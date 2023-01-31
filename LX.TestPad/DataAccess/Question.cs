using System.ComponentModel.DataAnnotations;

namespace LX.TestPad.DataAccess
{
    public class Question
    {

        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
