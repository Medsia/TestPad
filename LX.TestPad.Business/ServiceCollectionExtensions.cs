using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LX.TestPad.DataAccess
{
    public static class ServiceCollectionExtensions
    {
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
