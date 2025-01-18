using CvmReader.Application.Interfaces;
using CvmReader.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CvmReader.IoC.DependencyResolver
{
    public static class ServicesResolver
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<HttpClient>();
            services.AddScoped<ICompaniesService, CompaniesService>();

            return services;
        }
    }
}
