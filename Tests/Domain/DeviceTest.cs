using System;
using NUnit.Framework;
using Domain.Models;
namespace Tests.Domain
{
	[TestFixture]
	public class DeviceTest
	{
		[Test]
        [TestCase(1, 20.0)]
		[TestCase(2, 23.0)]
		[TestCase(3, 19.0)]

		public void DeviceTest_OK(int deviceId, double tempNow)
		{
			Device device = new Device(deviceId, tempNow);

			Assert.That(deviceId, Is.Not.Null);
			Assert.That(device.TempNow, Is.EqualTo(tempNow));
		}

    }
}

