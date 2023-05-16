using ShopApi.Db;
﻿using JsonApiSerializer.JsonConverters;
using Newtonsoft.Json;
using JsonApiSerializer.ContractResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPostgresStorage(builder.Configuration["DbConnString"]);
builder.Services.AddControllers()
    .AddNewtonsoftJson(opts =>
    {
        opts.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
        opts.SerializerSettings.ContractResolver = new JsonApiContractResolver(new ResourceObjectConverter());
        opts.SerializerSettings.DateParseHandling = DateParseHandling.None;
    });;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RouteOptions>(options => 
{
    options.LowercaseUrls = true;   
}); 

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