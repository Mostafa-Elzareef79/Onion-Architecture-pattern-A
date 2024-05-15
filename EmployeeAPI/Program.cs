using Employee.Application;
using Employee.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persestance;
using Persestance.Context;
namespace EmployeeAPI
{
    public class Program
    {
        public IConfiguration ConfigurationManager { get; set; }
        public static void Main(string[] args)
        {  
        var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EmployeeDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("cs"), b =>
             {
                 b.MigrationsAssembly(typeof(EmployeeDbContext).Assembly.FullName);
             })
         );
            // Add services to the container.
            builder.Services.AddScoped<IEmployeeDbContext,EmployeeDbContext>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplication();
         

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

            app.Run();
        }
    }
}
