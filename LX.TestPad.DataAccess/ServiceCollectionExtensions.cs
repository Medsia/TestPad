using LX.TestPad.DataAccess.Interfaces;
using LX.TestPad.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LX.TestPad.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, string sqlConnectionString)
        {
            services.AddDbContextPool<DataContext>(options => options.UseSqlServer(sqlConnectionString));

            return services;
        }

        public static IServiceCollection AddEfRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IResultAnswerRepository, ResultAnswerRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<ITestQuestionRepository, TestQuestionRepository>();
            services.AddScoped<ITestRepository, TestRepository>();

            return services;
        }
    }
}
