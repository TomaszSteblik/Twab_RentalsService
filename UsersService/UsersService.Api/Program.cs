using System.Reflection;
using MediatR;
using MongoDB.Driver;
using UsersService.Application.Commands.AddUser;
using UsersService.Application.DTOs;
using UsersService.Application.Queries.GetUser;
using UsersService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();
builder.Services.AddMediatR(Assembly.Load("UsersService.Application"));
builder.Services.AddAutoMapper(Assembly.Load("UsersService.Application"), Assembly.Load("UsersService.Infrastructure"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/Users/{id}", async (Guid id, IMediator mediator) => 
    await mediator.Send(new GetUserQuery(id))).WithTags("Users");
app.MapPost("/Users", async (AddUserDto addUserDto, IMediator mediator) => 
    await mediator.Send(new AddUserCommand(addUserDto))).WithTags("Users");

app.Run();