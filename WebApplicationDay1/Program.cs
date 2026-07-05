
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using WebApplicationDay1.Models;
using WebApplicationDay1.Repository;

namespace WebApplicationDay1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = "AllowAll";
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

            builder.Services.AddScoped<StudentsRepository>();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "My API",
                        Version = "v1",
                        Description = "This is my API description",
                        Contact = new OpenApiContact { Email = "moaaz@gmail.com" }
                    });

                options.EnableAnnotations();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(text);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
