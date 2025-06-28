using System;
using Domain.Repozitorijumi.HeaterRepozitorijum;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class HeaterRepozitorijumTests
    {
        [Test]
        public void AzurirajPocetakRada_AzurirajKrajRada_UpdatesTotalTimeAndConsumption()
        {
            // Arrange
            var repo = new HeaterRepozirorijum();
            DateTime startTime = DateTime.UtcNow;
            repo.AzurirajPocetakRada(startTime);

            // Simulacija rada od 30 minuta
            DateTime endTime = startTime.AddMinutes(30);
            double consumption = 15.5;

            // Act
            repo.AzurirajKrajRada(endTime, consumption);
            TimeSpan totalTime = repo.UkupnoRadnoVreme();
            double totalConsumption = repo.UkupnaPotrosnja();

            // Assert
            Assert.That(totalTime.TotalMinutes, Is.GreaterThanOrEqualTo(30));
            Assert.That(totalConsumption, Is.EqualTo(consumption).Within(0.0001));
            Assert.That(repo.TrenutniPocetakRada(), Is.Null); // ako se resetuje nakon kraja rada
        }
    }
}
