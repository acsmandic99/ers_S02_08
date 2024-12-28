using System;
using Domain.Models;
using Domain.Services;

namespace Services.HeaterServisi
{
	public class HeaterServisUkljuci : IHeaterServiceUkljuci
	{
        private readonly Heater _heater;
        private bool ukljucen = true;

        public HeaterServisUkljuci(Heater heater)
        {
            _heater = heater;
        }

        public bool UkljuciPec(bool ukljucen)
        {
            _heater.Ukljucen = ukljucen; 
            return _heater.Ukljucen;
        }
    }
}

