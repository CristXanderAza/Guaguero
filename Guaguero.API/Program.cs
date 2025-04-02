using Guaguero.Application.NotifInterfaces;
using Guaguero.InOC.Travels;
using Guaguero.Persistence.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<GuagueroContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBGuaguero")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<ITravelNotificator, TravelNotificator>();
builder.Services.RegisterTravelDependencies();
builder.Services.AddSwaggerGen();

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
