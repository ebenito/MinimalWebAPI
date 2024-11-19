//Demo conversión de la plantilla a una Web API minima
using MinimalWebAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/api/greet/{name}", (string name) => $"Hello, {name}!");
app.MapGet("/weatherforecast", () => WeatherForecastService.GetForecasts());

app.Run();

