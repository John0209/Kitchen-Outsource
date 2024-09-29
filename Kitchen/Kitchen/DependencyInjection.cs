using System.Reflection;
using System.Text.Json.Serialization;
using Kitchen.Application.Gateway.Configuration;
using Kitchen.Application.Gateway.IConfiguration;
using Kitchen.Application.UnitOfWork;
using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Repositories;
using Kitchen.Infrastructure.Repositories.IRepositories;
using Kitchen.Infrastructure.Services;
using Kitchen.Infrastructure.Services.IServices;
using RecipeCategoryEnum.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Kitchen;

public static class DependencyInjection
{
    public static IServiceCollection AddDependency(this IServiceCollection services, string dbConnection = "")
    {
        //Db context
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConnection));

        //Add repo
        services.Scan(scan => scan
            .FromAssembliesOf(typeof(IBaseRepository<>), typeof(BaseRepository<>))
            .AddClasses(classes => classes.AssignableTo(typeof(BaseRepository<>)), publicOnly: true)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddMediatR(x => { x.RegisterServicesFromAssembly(typeof(Program).Assembly); });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IMomoConfig, MomoConfig>();
        services.AddScoped<IDriveConfig, DriveConfig>();
        services.AddScoped<IMomoService, MomoService>();
        services.AddScoped<IDriveService, DriveService>();
        services.AddScoped<IFireBaseConfig, FireBaseConfig>();
        services.AddScoped<IFirebaseService, FireBaseService>();
        
        services.AddControllers()
            //allow enum string value in swagger and front-end instead of int value
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddSwaggerGen(ops =>
        {
            ops.MapType<DateTime>(() => new OpenApiSchema()
            {
                Type = "string",
                Format = "date",
                Example = new OpenApiString(DateTime.Now.ToString("yyyy-MM-dd"))
            });

            ops.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Kitchen", Version = "v1", Description = "ASP NET core API for Kitchen project."
                });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            ops.IncludeXmlComments(xmlPath);
        });
        return services;
    }
}