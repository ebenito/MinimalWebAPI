namespace MinimalWebAPI
{
	public class WeatherForecast
	{
		public DateTime Date { get; set; }
		public int TemperatureC { get; set; }
		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
		public string? Summary { get; set; }
	}

	public static class WeatherForecastService
	{
		private static readonly string[] Summaries = new[]
		{
			"Helado", "Refrescante", "Frío", "Fresco", "Templado", "Cálido", "Agradable", "Caliente", "Sofocante", "Abrasador"
		};

		public static IEnumerable<WeatherForecast> GetForecasts()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}

}
