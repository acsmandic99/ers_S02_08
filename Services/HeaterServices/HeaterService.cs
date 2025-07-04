using System;
using Domain.Models;
using Domain.Services;
namespace Services.HeaterServices
{
	public class HeaterService : IHeaterService
	{
		private static Heater _heater;
		private readonly ILoggerService _logger;

		public HeaterService(Heater heater, ILoggerService logger)
		{
			_heater = heater;
			_logger = logger;
		}

		public bool TurnOff()
		{
			if(_heater.IsActive)
			{
				_logger.Log($"Pec je iskljucena.");
				_heater.IsActive = false;
				return true;
			}
			return false;

		}

		public bool TurnOn()
		{
			if(!_heater.IsActive)
			{
				_heater.IsActive = true;
                _heater.ResorceUsed++;
                _logger.Log($"Pec je ukljucena.");
				_logger.Log($"Utroseni resursi: {_heater.ResorceUsed} kWh");
				return true;
			}
			return false;
		}

		public bool IsActive()
		{
			return _heater.IsActive;
		}
		
	}
}

