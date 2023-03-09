using System.ComponentModel.DataAnnotations;

namespace LX.TestPad.DataAccess.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; } = default!;
        
        public string? CodeSnippet { get; set; }

        public virtual List<Answer> Answers { get; set; }
    }
}
