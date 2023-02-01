using LX.TestPad.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPad.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                },
                ServiceLifetime.Transient
            );

            services.AddScoped<Dictionary<Type, DataContext>>();
            services.AddSingleton<DbContextFactory>();
            services.AddSingleton<IAnswerRepository, AnswerRepository>();
            services.AddSingleton<IQuestionRepository, QuestionRepository>();
            services.AddSingleton<IResultAnswerRepository, ResultAnswerRepository>();
            services.AddSingleton<IResultRepository, ResultRepository>();
            services.AddSingleton<ITestQuestionRepository, TestQuestionRepository>();
            services.AddSingleton<ITestRepository, TestRepository>();

            return services;
        }
    }
}
