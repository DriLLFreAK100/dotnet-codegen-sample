﻿using System.Reflection;
using CodeGenerator;
using CodeGenerator.Models;
using SampleWebApiGenerator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Configure Code Generator
    new TypeScript(new Option()
    {
        IsDryRun = false,
        RelativeBaseOutputPath = "../../../GeneratedOutputs",
        TargetAssemblies = new()
        {
            Assembly.GetAssembly(typeof(WeatherForecast)),
        }
    }).Generate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

