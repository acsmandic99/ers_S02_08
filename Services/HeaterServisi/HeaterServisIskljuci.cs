using System;
using Domain.Models;
using Domain.Services;

namespace Services.HeaterServisi
{
    public class HeaterServisIskljuci : IHeaterServiceIskljuci
    {
        private readonly Heater _heater;
        private bool ukljucen = false;

        public HeaterServisIskljuci(Heater heater)
        {
            _heater = heater;
        }

        public bool IskljuciPec(bool ukljucen)
        {
            _heater.Ukljucen = ukljucen; 
            return _heater.Ukljucen;
        }
    }
}

