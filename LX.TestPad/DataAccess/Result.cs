using System.ComponentModel.DataAnnotations;

namespace LX.TestPad.DataAccess
{
    public class Result
    {

        [Key]
        public int Id { get; set; }
        public int TestId { get; set; }

        public string UserName { get; set; }
        public double Score { get; set; }

        public virtual Test Test { get; set; }
    }
}
