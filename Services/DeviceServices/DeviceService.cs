using System;
using Domain.Services;
using Domain.Models;
using Domain.Constants;
using Domain.Repositories.DeviceRepositories;
namespace Services.DeviceServices
{
	public class DeviceService : IDeviceService
	{
		private readonly IDeviceRepository _deviceRepo;
		private readonly ILoggerService _logger;
		

		public DeviceService(IDeviceRepository deviceRepo, ILoggerService logger)
		{
			_logger = logger;
			_deviceRepo = deviceRepo;
		}

		public bool AddNewDevice(Device device)
		{
			return _deviceRepo.AddDevice(device);
		}

		public IEnumerable<double> GetDevicesTemperatures()
		{
			List<double> test = new List<double>();
			var temp = _deviceRepo.GetDevices();
			//return _deviceRepo.GetDevices().Select(d => d.TempNow).ToList();
			foreach(Device d in _deviceRepo.GetDevices())
			{
				test.Add(d.TempNow);

			}
			return test;
		}

		public bool UpdateTemperatures(double on, double off, bool isActive)
		{
			var devices = _deviceRepo.GetDevices();
			
            
            foreach (var device in devices)
			{
			double newTemp = isActive ? device.TempNow + on : Math.Max(0, device.TempNow - off);

			newTemp = Math.Round(newTemp, 4);

			_deviceRepo.UpdateDevice(device.IdDevice, newTemp);
			_logger.Log($"[UPDATE] Device {device.IdDevice} nova temperatura: {newTemp} ºC");
			}
			return true;
			
		}

    }
}
