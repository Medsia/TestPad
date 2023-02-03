using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Services;
using LX.TestPad.DataAccess.Interfaces;
using LX.TestPad.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LX.TestPad.DataAccess
{
    public static class ServiceCollectionExtensions
    {
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

        public static IServiceCollection AddBusinesLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IResultAnswerService, ResultAnswerService>();
            services.AddScoped<IResultService, ResultService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ITestQuestionService, TestQuestionService>();

            return services;
        }
    }
}
