using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Business.Services;
using Logeecom.AsyncProgramming.DataAccess;
using Logeecom.AsyncProgramming.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContextEF>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("MoviesDb"))
);

builder.Services.AddScoped<FilmServiceTraditionalAsync>();
builder.Services.AddScoped<IAwardRepositorySync, AwardRepositorySync>();
builder.Services.AddScoped<IGenreRepositorySync, GenreRepositorySync>();
builder.Services.AddScoped<IActorRepositorySync, ActorRepositorySync>();
builder.Services.AddScoped<IDirectorRepositorySync, DirectorRepositorySync>();
builder.Services.AddScoped<IFilmRepositorySync, FilmRepositorySync>();

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