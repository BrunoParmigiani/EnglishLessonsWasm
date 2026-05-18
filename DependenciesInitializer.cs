using EnglishLessonsWasm.Lessons;
using EnglishLessonsWasm.Lessons.Mappings;
using FluentValidation;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependenciesIntializer
    {
        public static IServiceCollection Initialize(this IServiceCollection services)
        {
            services.AddScoped<ILessonsData, LessonsData>();

            services.AddAutoMapper(config => { }, typeof(ModelToDTOMapProfile));

            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(assembly);
            });
                        
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}