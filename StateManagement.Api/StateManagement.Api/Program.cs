using Microsoft.EntityFrameworkCore;
using StateManagement.Business.Services;
using StateManagement.Business.Services.Base;
using StateManagement.Data.Context;
using StateManagement.Data.Repositories;
using StateManagement.Data.Repositories.Base.Interfaces;

var builder = WebApplication.CreateBuilder(args);

IWebHostEnvironment environment = builder.Environment;

builder.Configuration.AddJsonFile("appsettings.json", false, true);
builder.Configuration.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", false, true);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StateManagementContext>(options => options.UseSqlServer(configuration.GetConnectionString("StateManagementDB")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFlowService, FlowService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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
