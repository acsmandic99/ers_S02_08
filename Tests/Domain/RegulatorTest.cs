using System;
using Domain.Models;
using NUnit.Framework;
namespace Tests.Domain
{
	[TestFixture]
	public class RegulatorTest
	{
		[Test]
		[TestCase(7, 22, 24.0, 18.0)]
		[TestCase(5, 19, 15.0, 9.0)]
		[TestCase(9, 21, 30.0, 25.0)]

		public void RegulatorService_OK(int start, int end, double tempDay, double tempNight)
		{
			Regulator regulator = new Regulator(start, end, tempDay, tempNight);

			Assert.That(regulator.WorkStart, Is.EqualTo(start));
            Assert.That(regulator.WorkEnd, Is.EqualTo(end));
            Assert.That(regulator.TemperatureDay, Is.EqualTo(tempDay));
            Assert.That(regulator.TemperatureNight, Is.EqualTo(tempNight));

        }

    }
}

