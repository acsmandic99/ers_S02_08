using Domain.Constants;
using Helpers.Temperature;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class GenerisanjeTemperatureTests
    {
        [Test]
        [TestCase(20.0, true)]
        public void GenerisiTemperaturu_Increase_ReturnsIncrementedValue(double trenutnaTemp, bool povecaj)
        {
            // Act
            double novaTemp = GenerisanjeTemperature.GenerisiTemperaturu(trenutnaTemp, povecaj);

            // [IZMENJENO]: Očekivana vrednost je trenutnaTemp + PovecanjeTemperature
            double expected = trenutnaTemp + RegulatorConstants.PovecanjeTemperature;

            // Assert
            Assert.That(novaTemp, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(5.0, false)]
        [TestCase(20.0, true)]
        [TestCase(15.0, true)]
        [TestCase(0.0, true)]

        public void GenerisiTemperaturu_Decrease_ReturnsDecreasedValueOrZero(double trenutnaTemp, bool povecaj)
        {
            // Arrange
            double expected = trenutnaTemp - (RegulatorConstants.PovecanjeTemperature * RegulatorConstants.SmanjenjeFaktoraTemperature);
            if (expected < 0)
                expected = 0;

            // Act
            double novaTemp = GenerisanjeTemperature.GenerisiTemperaturu(trenutnaTemp, povecaj);

            // Assert
            Assert.That(novaTemp, Is.EqualTo(expected).Within(0.0001));
        }
    }
}
