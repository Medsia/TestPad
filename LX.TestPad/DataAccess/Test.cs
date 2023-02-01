using System.ComponentModel.DataAnnotations;

namespace LX.TestPad.DataAccess
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TestDuration { get; set; }
    }
}
