
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using WebApplicationDay1.Models;

namespace WebApplicationDay1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = "";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Cors Configuration 
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(text,
                builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<ITIContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(
                    builder.Configuration.GetConnectionString("ITIConnection")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(text);

            app.MapControllers();

            app.Run();
        }
    }
}
