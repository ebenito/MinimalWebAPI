//Demo conversión de la plantilla a una Web API minima
using MinimalWebAPI;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/api/greet/{name}", (string name) => $"Hello, {name}!");
app.MapGet("/weatherforecast", () => WeatherForecastService.GetForecasts());

// Nuevo endpoint para obtener la IP del usuario
app.MapGet("/api/get-ip", (HttpContext httpContext) =>
{
	var ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();

	// Verificar encabezados para obtener IP detrás de proxies
	if (httpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
	{
		ipAddress = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
	}

	return ipAddress ?? "IP desconocida";
});


app.Run();