using Kontent.Bridge.QueueOverview.Api.Middleware;
using Kontent.Bridge.QueueOverview.Application;
using Kontent.Bridge.QueueOverview.Infrastructure;

namespace Kontent.Bridge.QueueOverview.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bridge message queue overview API");
                });
            }

            app.UseHttpsRedirection();

            app.UseCustomExceptionHandler();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
