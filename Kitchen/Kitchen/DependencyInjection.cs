using System.Reflection;
using System.Text.Json.Serialization;
using Kitchen.Infrastructure.DbContext;
using Kitchen.Infrastructure.Interfaces.IRepositories;
using Kitchen.Infrastructure.Repositories;
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

        //services.AddScoped<IUnitOfWork, UnitOfWork>();
        // services.AddScoped<ICloudConfig, CloudConfig>();
        // services.AddScoped<IMomoConfig, MomoConfig>();

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
                    Title = "Actor", Version = "v1", Description = "ASP NET core API for Actor project."
                });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            ops.IncludeXmlComments(xmlPath);
        });
        return services;
    }
}