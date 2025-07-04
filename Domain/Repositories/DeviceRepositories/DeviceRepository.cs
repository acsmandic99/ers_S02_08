using System;
using Domain.Repositories;
using Domain.Models;
namespace Domain.Repositories.DeviceRepositories
{
	public class DeviceRepository : IDeviceRepository
	{
        private static List<Device> _devices;

        static DeviceRepository()
		{
			_devices = new List<Device>
			{
				new Device(1, 20.0),
				new Device(2, 21.0),
				new Device(3, 19.0),
				new Device(4, 24.0)
				//uvek se moze dodati vise uredjaja
			};

		}

		public bool AddDevice(Device device)
		{
			if (_devices.Any(d => d.IdDevice == device.IdDevice))
				return false;

			_devices.Add(device);
			return true;
		}

		public IEnumerable<Device> GetDevices()
		{
			return _devices;
		}

		public bool UpdateDevice(int id, double newTemp)
		{
			var device = _devices.FirstOrDefault(d => d.IdDevice == id);
			if (device == null)
				return false;

			device.TempNow = newTemp;
			return true;
		}
	}
}

