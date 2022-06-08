using Microsoft.EntityFrameworkCore;

namespace StockMonitor;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await WebApplication.CreateBuilder(args)
            .RegisterServices()
            .Build()
            .ConfigureMiddleware()
            .RunAsync();
    }

    private static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContextPool<AppDbContext>(options => options.UseInMemoryDatabase(nameof(StockMonitor)));
        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        return builder;
    }

    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        return app;
    }
}


