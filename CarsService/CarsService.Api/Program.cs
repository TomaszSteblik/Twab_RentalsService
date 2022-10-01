using System.Reflection;
using CarsService.Application.Commands.AddCar;
using CarsService.Application.DTOs;
using CarsService.Application.Queries.GetCar;
using CarsService.Application.Queries.GetUserCars;
using CarsService.Infrastructure.EF;
using CarsService.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarsServiceContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("CarsConnString")));
builder.Services.AddInfrastructure();
builder.Services.AddMediatR(Assembly.Load("CarsService.Application"));
builder.Services.AddAutoMapper(Assembly.Load("CarsService.Application"), Assembly.Load("CarsService.Infrastructure"));

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapPost("/Cars", async (WriteCarDto writeCarDto, IMediator mediator) => 
    await mediator.Send(new AddCarCommand(writeCarDto))).WithTags("Cars");
app.MapGet("/Cars/User/{id}", async (Guid id, IMediator mediator) => 
    await mediator.Send(new GetUserCarsQuery(id))).WithTags("Cars");
app.MapGet("/Cars/{id}", async (Guid id, IMediator mediator) => 
    await mediator.Send(new GetCarQuery(id))).WithTags("Cars");

app.Run();