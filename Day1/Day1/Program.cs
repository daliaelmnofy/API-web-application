
using Day1.Database;
using Day1.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Day1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();


            builder.Services.AddDbContext<APIsContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
            });

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("MyPolicy", corsPolicy =>
                {
                    corsPolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseCors("MyPolicy");
            
            app.MapControllers();

            app.Run();
        }
    }
}
