using System.Reflection;
using System.Text.Json;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => JsonSerializer.Deserialize<Error>(e.ErrorMessage));

            return new BadRequestObjectResult(errors);
        };
    })
    .AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

builder.Services.AddTransient<IValidatorInterceptor, UseCustomErrorModelInterceptor>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();