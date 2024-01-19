using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SimpleWebApiProject.Data;
using SimpleWebApiProject.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StudentDetails>());

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
