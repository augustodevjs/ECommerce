using ECommerce.Application;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDependeciesApplication();
builder.Services.AddDependeciesInfraestructure();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);
builder.Services.Configure<ApiBehaviorOptions>(o => o.SuppressModelStateInvalidFilter = true);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();