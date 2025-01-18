using CvmReader.IoC.DependencyResolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CvmReader.IoC.Builder
{
    public class WebApiBuilder
    {
        public void Run(WebApplicationBuilder builder)
        {
            ConfigureServices(builder.Services);
            ConfigureBuilder(builder.Build());
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services
                .AddServices()
                .AddMapper()
                .AddSwagger()
                .AddControllers();
        }

        private static void ConfigureBuilder(WebApplication app)
        {
            app.UseHttpsRedirection()
                .UseAuthorization()
                .UseSwaggerConfiguration()
                .UseCorsConfiguration();

            app.MapControllers();
            app.Run();
        }
    }
}