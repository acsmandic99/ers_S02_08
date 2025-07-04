using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Repositories.DeviceRepositories;
using Domain.Services;
using Moq;
using NUnit.Framework;
using Services.DeviceServices;

namespace Tests.Services
{
    [TestFixture]
    public class DeviceServiceTests
    {
        private Mock<IDeviceRepository> _deviceRepoMock;
        private Mock<ILoggerService> _loggerMock;
        private DeviceService _deviceService;

        [SetUp]
        public void Setup()
        {
            _deviceRepoMock = new Mock<IDeviceRepository>();
            _loggerMock = new Mock<ILoggerService>();
            _deviceService = new DeviceService(_deviceRepoMock.Object, _loggerMock.Object);
        }

        [Test]
        public void AddNewDevice_Should_Call_Repo_And_Return_True()
        {
            // Arrange
            var newDevice = new Device(5, 22.0);
            _deviceRepoMock.Setup(r => r.AddDevice(newDevice)).Returns(true);

            // Act
            var result = _deviceService.AddNewDevice(newDevice);

            // Assert
            Assert.IsTrue(result);
            _deviceRepoMock.Verify(r => r.AddDevice(newDevice), Times.Once);
        }

        [Test]
        public void GetDevicesTemperatures_Should_Return_All_Temperatures()
        {
            // Arrange
            var devices = new List<Device>
            {
                new Device(1, 20.5),
                new Device(2, 21.7),
                new Device(3, 19.0)
            };
            _deviceRepoMock.Setup(r => r.GetDevices()).Returns(devices);

            // Act
            var temps = _deviceService.GetDevicesTemperatures().ToList();

            // Assert
            Assert.AreEqual(3, temps.Count);
            Assert.AreEqual(20.5, temps[0]);
            Assert.AreEqual(21.7, temps[1]);
            Assert.AreEqual(19.0, temps[2]);
        }

        [Test]
        public void UpdateTemperatures_Should_Update_All_Devices_When_Active()
        {
            // Arrange
            var devices = new List<Device>
            {
                new Device(1, 20.0),
                new Device(2, 25.0)
            };
            _deviceRepoMock.Setup(r => r.GetDevices()).Returns(devices);

            // Act
            var result = _deviceService.UpdateTemperatures(2.5, 1.0, true);

            // Assert
            Assert.IsTrue(result);
            _deviceRepoMock.Verify(r => r.UpdateDevice(1, 22.5), Times.Once);
            _deviceRepoMock.Verify(r => r.UpdateDevice(2, 27.5), Times.Once);
            _loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void UpdateTemperatures_Should_Decrease_All_Devices_When_Inactive()
        {
            // Arrange
            var devices = new List<Device>
            {
                new Device(1, 5.0),
                new Device(2, 1.0)
            };
            _deviceRepoMock.Setup(r => r.GetDevices()).Returns(devices);

            // Act
            var result = _deviceService.UpdateTemperatures(2.5, 2.0, false);

            // Assert
            Assert.IsTrue(result);
            _deviceRepoMock.Verify(r => r.UpdateDevice(1, 3.0), Times.Once);
            _deviceRepoMock.Verify(r => r.UpdateDevice(2, 0.0), Times.Once);  // Math.Max(0, -1) = 0
            _loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
