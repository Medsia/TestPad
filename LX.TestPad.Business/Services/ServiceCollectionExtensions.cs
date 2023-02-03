using LX.TestPad.Business.Interfaces;
using LX.TestPad.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LX.TestPad.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinesLogicServices(this IServiceCollection services)
        {
            services.AddSingleton<IAnswerService, AnswerService>();
            services.AddSingleton<IQuestionService, QuestionService>();
            services.AddSingleton<IResultAnswerService, ResultAnswerService>();
            services.AddSingleton<IResultService, ResultService>();
            services.AddSingleton<ITestQuestionService, TestQuestionService>();
            services.AddSingleton<ITestService, TestService>();

            return services;
        }
    }
}
