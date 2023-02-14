using System.ComponentModel.DataAnnotations;

namespace LX.TestPad.DataAccess.Entities
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TestDuration { get; set; }
        public bool IsPublished { get; set; }
    }
}
