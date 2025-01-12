using System;
using Domain.Models;
using Domain.Services;
using Services.HeaterServisi;
namespace Services.HeaterServisi
{
	public class HeaterService : IHeaterService
	{
        private readonly Heater _heater;

        public HeaterService(Heater heater)
        {
            _heater = heater;
        }

        public void Ukljuci()
        {
            _heater.UkljuciPec();
        }

        public void Iskljuci()
        {
            _heater.IskljuciPec();
        }

    }
}

