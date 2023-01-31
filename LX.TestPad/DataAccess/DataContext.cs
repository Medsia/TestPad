﻿using Microsoft.EntityFrameworkCore;

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
                //action.HasData();
            });
        }

        private void BuildQuestions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(action =>
            {
                //action.HasData();
            });
        }

        private void BuildAnswers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(action =>
            {
                //action.HasData();
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
