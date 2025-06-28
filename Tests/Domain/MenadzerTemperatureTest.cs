using Domain.Constants;
using Domain.Models;
using NUnit.Framework;
using Domain.Interfejsi;

namespace Tests.Domain
{
    [TestFixture]
    public class MenadžerTemperaturaTests
    {
        [Test]
        public void DodajTemperaturu_IzracunajProsecnuTemperaturu_ReturnsCorrectAverage()
        {
            // Arrange
            ITemperaturaMenadzer manager = new MenadzerTemperatura();
            double temp1 = 20.0;
            double temp2 = 22.0;
            double temp3 = 18.0;
            double temp4 = 24.0;

            // Act
            manager.DodajTemperaturu(temp1);
            manager.DodajTemperaturu(temp2);
            manager.DodajTemperaturu(temp3);
            manager.DodajTemperaturu(temp4);
            double avg = manager.IzracunajProsecnuTemperaturu();

            // Assert
            double expectedAvg = (temp1 + temp2 + temp3 + temp4) / RegulatorConstants.MaxUredjaj;
            Assert.That(avg, Is.EqualTo(expectedAvg).Within(0.0001));
        }
    }
}
