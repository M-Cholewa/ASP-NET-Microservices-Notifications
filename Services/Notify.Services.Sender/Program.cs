using Notify.Application;
using Notify.Infrastructure;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Notify.Services.Sender.Tasks;
using Hangfire;
using Hangfire.MemoryStorage;

namespace Notify.Services.Sender;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddHangfire(config =>
        {
            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                  .UseSimpleAssemblyNameTypeSerializer()
                  .UseDefaultTypeSerializer()
                  .UseMemoryStorage();
        });

        builder.Services.AddHangfireServer();

        builder.Services.RegistryInfrastructure(builder.Configuration);
        builder.Services.RegistryApplication();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            c.ExampleFilters();
        });
        
        builder.Services.AddLogging();

        builder.Services.AddScoped<DispatcherTask>();

        builder.Services.AddHostedService<DispatcherTaskHostedService>();

        var app = builder.Build();

        if (builder.Environment.IsDevelopment())
        {
            // app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notify API v1"));
        }

        app.MapControllers();


        app.Run();
    }
}