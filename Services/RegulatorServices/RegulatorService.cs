using System;
using Domain.Models;
using Domain.Services;
using Domain.Enums;
using Helpers.AverageTemperature;
namespace Services.RegulatorServices
{
	public class RegulatorService : IRegulatorService
	{
		private readonly IDeviceService _deviceService;
		private readonly IHeaterService _heaterService;
		private readonly Regulator _regulator;
		private  IEnumerable<double> _devTemps;
		private readonly AverageTemperature _avg;

		public RegulatorService(IDeviceService deviceService, IHeaterService heaterService, Regulator regulator, AverageTemperature avg)
		{
			_deviceService = deviceService;
			_heaterService = heaterService;
			_regulator = regulator;
			//_devTemps = Enumerable.Empty<double>();
			_avg = avg;
		}

		public IEnumerable<double> GetTemps()
		{
			_devTemps = _deviceService.GetDevicesTemperatures();
			return _devTemps;
		}

		public void StartHeating()
		{
			_devTemps = _deviceService.GetDevicesTemperatures();
			double avgNow = _avg.AverageTemp(_devTemps);

			if((_regulator.Regime == RegulatorRezimRada.DAY && avgNow <= _regulator.TemperatureDay) || (_regulator.Regime == RegulatorRezimRada.NIGHT && avgNow <= _regulator.TemperatureNight))
			{
				_heaterService.TurnOn();
				_deviceService.UpdateTemperatures(1, 0.5, _heaterService.IsActive());
			}
		}

		public void StopHeating()
		{
            _devTemps = _deviceService.GetDevicesTemperatures();
            double avgNow = _avg.AverageTemp(_devTemps);

            if ((_regulator.Regime == RegulatorRezimRada.DAY && avgNow > _regulator.TemperatureDay) || (_regulator.Regime == RegulatorRezimRada.NIGHT && avgNow > _regulator.TemperatureNight))
            {
                _heaterService.TurnOff();
                _deviceService.UpdateTemperatures(1, 0.5, _heaterService.IsActive());
            }
        }
	}
}

