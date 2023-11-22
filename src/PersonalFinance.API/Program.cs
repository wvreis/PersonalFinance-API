using Microsoft.EntityFrameworkCore;
using PersonalFinance.Application;
using PersonalFinance.Application.ExceptionMiddlewares;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Infrastructure.Persistence;
using PersonalFinance.Infrastructure.Repositories;

const string UIPolicy = "UIPolicy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var corsOrigin = builder.Configuration.GetValue<string>("CorsOrigin") ?? throw new InvalidOperationException("Cors Origin not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddApplicationDI();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: UIPolicy,
        policy  => {
            policy
                //.WithOrigins(corsOrigin)
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddHostedService<AppDbContextSeedDatabase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(UIPolicy);

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
