using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.Application.Commands.EndRental;
using RentalService.Application.Commands.StartNewRental;
using RentalService.Application.DTOs;
using RentalService.Application.Queries.GetAllAvailableCars;
using RentalService.Application.Queries.GetCar;
using RentalService.Application.Queries.GetRental;
using RentalService.Application.Queries.GetUserRentals;
using RentalService.Infrastructure.EF.DbAccess;
using RentalService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RentalServiceContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("RentalsConnString")));
builder.Services.AddInfrastructure();
builder.Services.AddMediatR(Assembly.Load("RentalService.Application"));
builder.Services.AddAutoMapper(Assembly.Load("RentalService.Application"), Assembly.Load("RentalService.Infrastructure"));

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

app.MapGet("/Rentals/User/{id}", async (Guid id, IMediator mediator) => 
    await mediator.Send(new GetUserRentalsQuery(id))).WithTags("Rentals");
app.MapGet("/Rentals/{id}", async (Guid id, IMediator mediator) => 
    await mediator.Send(new GetRentalQuery(id))).WithTags("Rentals");
app.MapPost("/Rentals/End/{rentalId}", async (Guid rentalId, IMediator mediator) => 
    await mediator.Send(new EndRentalCommand(rentalId))).WithTags("Rentals");
app.MapPost("/Rentals/Start", async ([FromBody] AddRentalDto rentalDto, IMediator mediator) => 
    await mediator.Send(new StartNewRentalCommand(rentalDto))).WithTags("Rentals");
app.MapGet("/Cars/{id}", async (Guid id, IMediator mediator) => 
    await mediator.Send(new GetCarQuery(id))).WithTags("Cars");
app.MapGet("/Cars/Available", async ( IMediator mediator) => 
    await mediator.Send(new GetAvailableCarsQuery())).WithTags("Cars");

app.Run();