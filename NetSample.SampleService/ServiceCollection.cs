using Microsoft.Extensions.DependencyInjection;
using NetSample.SampleService.Acl;
using NetSample.SampleService.Repositories;
using NetSample.SampleService.Services;

namespace NetSample.SampleService
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddSampleServiceServices(this IServiceCollection services)
        {
            services.AddTransient<BookAntiCorruptionLayer>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
