using DotNetEnv;
using Person.Application.Commands;
using Person.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
Env.Load();

builder.Services.AddInfrastructure(builder.Configuration);

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
