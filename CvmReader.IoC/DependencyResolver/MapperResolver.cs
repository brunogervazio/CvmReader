using CvmReader.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace CvmReader.IoC.DependencyResolver
{
    public static class MapperResolver
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CompanieMappingProfile));
            services.AddAutoMapper(typeof(QuarterlyInformationMappingProfile));

            return services;
        }
    }
}
