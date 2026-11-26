// This file is responsible for configuring and starting application

using Microsoft.EntityFrameworkCore;
using EventRegistrationAPI_RostyslavShcherbyk.Data;
using EventRegistrationAPI_RostyslavShcherbyk.Services;

namespace EventRegistrationAPI_RostyslavShcherbyk
{


    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();


            // Configure Swagger for testing API endpoints
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            // builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Register AppDbContext and connect to SQL Server using conection string
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register event service to handle event operations
            // In short, it creates 1 instance of EventSrvice per HTTP request and tells ASP.NET CORE to provide EventService when controller requests IEventService
            builder.Services.AddScoped<IEventService, EventService>();

            // Register registration service to handle registration operations
            builder.Services.AddScoped<IRegistrationService, RegistrationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
