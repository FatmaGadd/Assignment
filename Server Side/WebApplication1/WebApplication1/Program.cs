using Microsoft.EntityFrameworkCore;
using WebApplication1.dbContext;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            #endregion

            // Add services to the container.
            #region db connection
            builder.Services.AddDbContext<AssignmentContext>(db =>
                db.UseSqlServer(builder.Configuration.GetConnectionString("conn"))
                );
            #endregion
            #region DI
            builder.Services.AddScoped<IEntity<Department>, DepartmentRepository>();
            builder.Services.AddScoped<IEntity<Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IEmployee, EmployeeRepository>();

            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors("AllowAll");


            app.Run();
        }
    }
}