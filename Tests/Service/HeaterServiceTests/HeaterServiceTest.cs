using Domain.Models;
using Domain.Services;
using Moq;
using NUnit.Framework;
using Services.HeaterServices;

namespace Tests.Services
{
    [TestFixture]
    public class HeaterServiceTests
    {
        private Heater _heater;
        private Mock<ILoggerService> _loggerMock;
        private HeaterService _heaterService;

        [SetUp]
        public void SetUp()
        {
            _heater = new Heater();
            _loggerMock = new Mock<ILoggerService>();
            _heaterService = new HeaterService(_heater, _loggerMock.Object);
        }

        [Test]
        public void TurnOn_WhenOff_ShouldActivateAndIncrementResource()
        {
            // Arrange
            _heater.IsActive = false;
            _heater.ResorceUsed = 0;

            // Act
            var result = _heaterService.TurnOn();

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(_heater.IsActive);
            Assert.AreEqual(1, _heater.ResorceUsed);
            _loggerMock.Verify(l => l.Log(It.Is<string>(s => s.Contains("Pec je ukljucena."))), Times.Once);
            _loggerMock.Verify(l => l.Log(It.Is<string>(s => s.Contains("Utroseni resursi"))), Times.Once);
        }

        [Test]
        public void TurnOn_WhenAlreadyOn_ShouldDoNothing()
        {
            // Arrange
            _heater.IsActive = true;
            _heater.ResorceUsed = 5;

            // Act
            var result = _heaterService.TurnOn();

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(_heater.IsActive);
            Assert.AreEqual(5, _heater.ResorceUsed);
            _loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void TurnOff_WhenOn_ShouldDeactivate()
        {
            // Arrange
            _heater.IsActive = true;

            // Act
            var result = _heaterService.TurnOff();

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(_heater.IsActive);
            _loggerMock.Verify(l => l.Log(It.Is<string>(s => s.Contains("Pec je iskljucena."))), Times.Once);
        }

        [Test]
        public void TurnOff_WhenAlreadyOff_ShouldDoNothing()
        {
            // Arrange
            _heater.IsActive = false;

            // Act
            var result = _heaterService.TurnOff();

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(_heater.IsActive);
            _loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsActive_ShouldReturnCorrectState()
        {
            _heater.IsActive = true;
            Assert.IsTrue(_heaterService.IsActive());

            _heater.IsActive = false;
            Assert.IsFalse(_heaterService.IsActive());
        }
    }
}
