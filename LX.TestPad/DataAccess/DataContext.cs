using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultAnswer> ResultAnswers { get; set; }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildTests(modelBuilder);
            BuildQuestions(modelBuilder);
            BuildAnswers(modelBuilder);
            BuildResults(modelBuilder);
            BuildResultAnswers(modelBuilder);
        }

        private void BuildTests(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>(action =>
            {
                action.HasData(
                    new Test() { Id = 1, Name = "My first test", Description = "It's my first test for test" },
                    new Test() { Id = 2, Name = "Empty test", Description = "It's empty test for test" },
                    new Test() { Id = 3, Name = "My empty test V2.0", Description = "It's my empty test for test with 1 question and without answer" });
        });
        }

        private void BuildQuestions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(action =>
            {
                action.HasData(
                    new Question() { Id = 1, TestId = 1, Text = "It's my first test for test?" },
                    new Question() { Id = 2, TestId = 1, Text = "It's better test?" },
                    new Question() { Id = 3, TestId = 1, Text = "Do you love this test?" },
                    new Question() { Id = 4, TestId = 1, Text = "Do yo like what you see?" },
                    new Question() { Id = 5, TestId = 3, Text = "Do yo like what you see?" });
        });
        }

        private void BuildAnswers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(action =>
            {
                action.HasData(
                    new Answer() { Id = 1, QuestionId = 1, Text = "Yes", IsCorrect = true },
                    new Answer() { Id = 2, QuestionId = 1, Text = "No", IsCorrect = false },
                    new Answer() { Id = 3, QuestionId = 1, Text = "What?", IsCorrect = false },
                    new Answer() { Id = 4, QuestionId = 2, Text = "Yes", IsCorrect = true },
                    new Answer() { Id = 5, QuestionId = 2, Text = "No", IsCorrect = false },
                    new Answer() { Id = 6, QuestionId = 2, Text = "What?", IsCorrect = false },
                    new Answer() { Id = 7, QuestionId = 3, Text = "Yes", IsCorrect = true },
                    new Answer() { Id = 8, QuestionId = 3, Text = "No", IsCorrect = false },
                    new Answer() { Id = 9, QuestionId = 3, Text = "What?", IsCorrect = false },
                    new Answer() { Id = 10, QuestionId = 4, Text = "Yes", IsCorrect = true },
                    new Answer() { Id = 11, QuestionId = 4, Text = "No", IsCorrect = false },
                    new Answer() { Id = 12, QuestionId = 4, Text = "What?", IsCorrect = false });
    });
        }

        private void BuildResults(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>(action =>
            {
                //action.HasData();
            });
        }

        private void BuildResultAnswers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResultAnswer>(action =>
            {
                //action.HasData();
            });
        }
    }
}
