using LX.TestPad.DataAccess.Interfaces;

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
    }
}
