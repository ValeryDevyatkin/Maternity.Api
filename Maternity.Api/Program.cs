using Maternity.Application.Features.Patients;
using Maternity.Application.Repository;
using Maternity.Application.Repository.Common;
using Maternity.Persistence.Context;
using Maternity.Persistence.Repository;
using Maternity.Persistence.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Maternity.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Add services to the container.

        builder.Services.AddDbContext<MaternityDbContext>(options => options.UseNpgsql(connectionString));
        builder.Services.AddAutoMapper(typeof(PatientProfile));

        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        builder.Services.AddTransient<IPatientRepository, PatientRepository>();
        builder.Services.AddSingleton<PatientService>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Maternity Home API",
                Description = "ASP.NET Core Web API for managing Patients.",
            });

            // using System.Reflection;
            options.IncludeXmlComments(Path.Combine(
                AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);
        });

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