using System;
using Domain.Enums;
using Domain.Models;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class RegulatorTests
    {
        [Test]
        [TestCase(6, 22)]
        [TestCase(23, 6)]
        public void Regulator_Constructor_SetsCorrectRegime_BasedOnCurrentTime(int startHour, int endHour)
        {
            // Arrange
            DateTime now = DateTime.Now;
            DateTime today = now.Date;
            DateTime pocetak = today.AddHours(startHour);
            DateTime kraj = startHour < endHour
                ? today.AddHours(endHour)
                : today.AddDays(1).AddHours(endHour);

            var tempManager = new MenadzerTemperatura();

            // Act
            var regulator = new Regulator(tempManager, pocetak, kraj, 22, 18);

            RegulatorRezimRada expected =
                (now >= pocetak && now < kraj) ? RegulatorRezimRada.Dnevni : RegulatorRezimRada.Nocni;

            // Assert
            Assert.That(regulator.Rezim, Is.EqualTo(expected));
        }
    }
}
