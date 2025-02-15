using POInterview.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging()
    .ConfigureServices()
    .ConfigureCORS()
    .ConfigureExceptionHandling();

var app = builder.Build();

app.Configure();

app.Run();
