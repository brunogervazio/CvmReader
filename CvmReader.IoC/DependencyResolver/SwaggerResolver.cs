using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CvmReader.IoC.DependencyResolver
{
    public static class SwaggerResolver
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CVM CSV Reader",
                    Version = "v1",
                    Description = "API responsavel por ler os dados de companhias da CVM"
                });


                c.EnableAnnotations();
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "CVM CSV Reader");
                options.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
