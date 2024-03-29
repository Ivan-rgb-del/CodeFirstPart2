using CodeFirst.Service.Interfaces;
using CodeFirst.Service.Repository;
using CodeFirst.Service.Services;
using CodeFirst.Validator;
using CodeFirstPart2;
using CodeFirstPart2.Model;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<IEngineRepository, EngineRepository>();
builder.Services.AddTransient<IEngineTypeRepository, EngineTypeRepository>();

builder.Services.AddHttpClient<ICarValidationService, CarValidationService>();
builder.Services.AddScoped<CarValidator>();

builder.Services.AddScoped<IValidator<Engine>, EngineValidator>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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
