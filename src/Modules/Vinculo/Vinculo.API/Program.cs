using Core.Infrastructure.Extensions;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Vinculo.Application.Commands;
using Vinculo.Domain.Interfaces;
using Vinculo.Infrastructure.Persistence;
using Vinculo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
Env.Load();
var connectionString = builder.Configuration.GetConnectionString();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreatePersonCommand).Assembly));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
