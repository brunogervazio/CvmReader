using CvmReader.IoC.Builder;

var builder = WebApplication.CreateBuilder(args);
new WebApiBuilder().Run(builder);
