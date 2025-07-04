using System;
namespace Presentation.ImportTemperature
{
	public class ImportTemperature
	{
		public double TemperatureDay()
		{
			Console.Write("Unesite dnevnu temperaturu: ");
			double day = Double.Parse(Console.ReadLine());

			return day;
		}

		public double TemperatureNight()
		{
            Console.Write("Unesite nocnu temperaturu: ");
            double night = Double.Parse(Console.ReadLine());

			return night;
        }
    }
}

