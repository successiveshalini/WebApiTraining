using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MyTelevisionApi.Data;
using MyTelevisionApi.Model;
using MyTelevisionApi;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
//builder.Services.AddScoped<IEmployee, Employee>();  


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyTelevisionDBContext>(options => options.UseSqlServer(ConnectionString));
 builder.Services .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<MyTelivision>());
//builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(MyTelivision));

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
