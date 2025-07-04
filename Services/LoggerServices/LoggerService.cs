using System;
using System.Globalization;
using Domain.Services;
namespace Services.LoggerServices
{
	public class LoggerService : ILoggerService
	{
		private readonly string _path; 

		public LoggerService(string path = "Ispis.txt")
		{
			_path = path;
		}


        public void Log(string message)
		{
			using StreamWriter sw = new(_path, append: true);
			sw.Write($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)}]: {message}\n");
		}
	}
}

