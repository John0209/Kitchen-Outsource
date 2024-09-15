using Kitchen;
using Kitchen.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dbConnection = builder.Configuration.GetConnectionString("Database") ?? "";

builder.Services.AddDependency(dbConnection);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Add cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();