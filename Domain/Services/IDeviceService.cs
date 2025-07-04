using System;
using Domain.Models;
namespace Domain.Services
{
	public interface IDeviceService
	{
		public bool AddNewDevice(Device device);
		public IEnumerable<double> GetDevicesTemperatures();
		public bool UpdateTemperatures(double on, double off, bool isActive);
	}
}

