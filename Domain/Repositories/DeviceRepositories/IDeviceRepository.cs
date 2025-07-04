using System;
using Domain.Models;
namespace Domain.Repositories.DeviceRepositories
{
	public interface IDeviceRepository
	{
		public bool AddDevice(Device device);
		public IEnumerable<Device> GetDevices();
		public bool UpdateDevice(int id, double newTemp);
	}
}

