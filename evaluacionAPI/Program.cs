using evaluacionAPI.Data;
using evaluacionAPI.Repository;
using evaluacionAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();

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
