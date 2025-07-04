using System;
namespace Helpers.AverageTemperature
{
	public class AverageTemperature
	{
		public virtual double AverageTemp(IEnumerable<double> temperature)
		{
			if (temperature == null || !temperature.Any())
				return 0;

			Console.WriteLine($"Srednja temperatura: {temperature.Average()}");
			Console.WriteLine("----------------------------------------");
			return temperature.Average();
		}
	}
}

