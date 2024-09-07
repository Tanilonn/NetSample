using Microsoft.Extensions.DependencyInjection;
using NetSample.SampleService.Repositories;

namespace NetSample.SampleService
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddSampleServiceServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            return services;
        }
    }
}
