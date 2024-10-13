using Hangfire;
using Kitchen;
using Kitchen.Application.Gateway.Configuration;
using Kitchen.MiddleWare;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Logs
// Đường dẫn tệp log nằm ở thư mục gốc của ứng dụng
var logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "log.txt");

// Tạo thư mục nếu chưa tồn tại
var logDirectory = Path.GetDirectoryName(logFilePath);
if (!Directory.Exists(logDirectory))
{
    Directory.CreateDirectory(logDirectory);
}

// Cấu hình Serilog
builder.Host.UseSerilog((ctx, config) =>
{
    config
        .MinimumLevel.Warning() // Không ghi log mặc định
        .WriteTo.File(
            path: logFilePath,
            rollingInterval: RollingInterval.Day,
            rollOnFileSizeLimit: true,
            outputTemplate:"[{Timestamp:dd-MM-yyyy HH:mm:ss}]{NewLine}{Message}{NewLine}{NewLine}");
});
#endregion

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

#region Third-parties gateway

builder.Services.Configure<MomoConfig>(builder.Configuration.GetSection(MomoConfig.ConfigName));
builder.Services.Configure<DriveConfig>(builder.Configuration.GetSection(DriveConfig.ConfigName));
builder.Services.Configure<FireBaseConfig>(builder.Configuration.GetSection(FireBaseConfig.ConfigName));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAuthorization();
//useHangfire
app.UseHangfireDashboard();
app.MapHangfireDashboard();

// Lấy thể hiện của HangfireJobScheduler và gọi ScheduleJobs
using (var scope = app.Services.CreateScope())
{
    var jobScheduler = scope.ServiceProvider.GetRequiredService<HangfireJobScheduler>();
    jobScheduler.ScheduleJobs();
}

app.MapControllers();
app.Run();