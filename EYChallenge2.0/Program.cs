using EYChallenge2._0.Data.Configuration;
using EYChallenge2._0.Data.Repositories;
using EYChallenge2._0.Data.Repositories.Interfaces;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection("MongoDb"));
builder.Services.AddSingleton<IDatabaseConfig>(sp => sp.GetRequiredService<IOptions<DatabaseConfig>>().Value);

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IVacancyRepository, VacancyRepository>();
builder.Services.AddSingleton<IUserVacancyRepository, UserVacanccyRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
