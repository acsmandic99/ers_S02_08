using System.Collections.Generic;
using Domain.Enums;
using Domain.Models;
using Domain.Services;
using Helpers.AverageTemperature;
using Moq;
using NUnit.Framework;
using Services.RegulatorServices;

namespace Tests.Services
{
    [TestFixture]
    public class RegulatorServiceTests
    {
        private Mock<IDeviceService> _deviceServiceMock;
        private Mock<IHeaterService> _heaterServiceMock;
        private Mock<AverageTemperature> _avgMock;
        private Regulator _regulator;
        private RegulatorService _regulatorService;

        [SetUp]
        public void SetUp()
        {
            _deviceServiceMock = new Mock<IDeviceService>();
            _heaterServiceMock = new Mock<IHeaterService>();
            _avgMock = new Mock<AverageTemperature>();

            _regulator = new Regulator
            {
                TemperatureDay = 22.0,
                TemperatureNight = 18.0,
                Regime = RegulatorRezimRada.DAY
            };

            _regulatorService = new RegulatorService(
                _deviceServiceMock.Object,
                _heaterServiceMock.Object,
                _regulator,
                _avgMock.Object
            );
        }

        [Test]
        public void StartHeating_ShouldTurnOnHeaterAndUpdateTemps_WhenAverageBelowDayThreshold()
        {
            // Arrange
            var temps = new List<double> { 20.0, 21.0 };
            _deviceServiceMock.Setup(d => d.GetDevicesTemperatures()).Returns(temps);
            _avgMock.Setup(a => a.AverageTemp(It.IsAny<IEnumerable<double>>())).Returns(20.5);

            _heaterServiceMock.Setup(h => h.TurnOn()).Returns(true);
            _heaterServiceMock.Setup(h => h.IsActive()).Returns(true);

            // Act
            _regulatorService.StartHeating();

            // Assert
            _heaterServiceMock.Verify(h => h.TurnOn(), Times.Once);
            _deviceServiceMock.Verify(d => d.UpdateTemperatures(1, 0.5, true), Times.Once);
        }

        [Test]
        public void StartHeating_ShouldNotTurnOn_WhenAverageAboveThreshold()
        {
            // Arrange
            _deviceServiceMock.Setup(d => d.GetDevicesTemperatures()).Returns(new List<double> { 23.0 });
            _avgMock.Setup(a => a.AverageTemp(It.IsAny<IEnumerable<double>>())).Returns(23.0);

            // Act
            _regulatorService.StartHeating();

            // Assert
            _heaterServiceMock.Verify(h => h.TurnOn(), Times.Never);
        }
    }
}
