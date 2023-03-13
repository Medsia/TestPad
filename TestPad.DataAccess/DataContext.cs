using LX.TestPad.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<TestQuestion> TestQuestion { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultAnswer> ResultAnswers { get; set; }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
    }
}
