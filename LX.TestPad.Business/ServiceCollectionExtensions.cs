using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LX.TestPad.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEfRepositories(configuration.GetConnectionString("DefaultConnection"));

            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IResultAnswerService, ResultAnswerService>();
            services.AddScoped<IResultService, ResultService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ITestQuestionService, TestQuestionService>();
            services.AddSingleton<IEncoder, EncoderBase64>();

            return services;
        }
    }
}
