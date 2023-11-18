using Herokume.Application;
using Herokume.Application.Contracts.Infrastrcture.IdentityService;
using Herokume.Domain.Entities;
using Herokume.Infrastrcture;
using Herokume.Infrastrcture.Authentication;
using Herokume.Persisitance;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/herokumeinfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


builder.Host.UseSerilog();

builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddPersistanceService(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options => options.AddPolicy(
        name: "CorsPolicy",
        bldr => bldr.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
    ));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
