using System;
using Domain.Models;
using Domain.Repozitorijumi.HeaterRepozitorijum;
using Domain.Services;
namespace Services.HeaterUkljuciServices
{
	public class HeaterUkljuciService : IHeaterUkljuciService
	{
        private readonly Heater _heater;
        private readonly IHeaterRepozitorijum _repository = new HeaterRepozirorijum();

        public HeaterUkljuciService(Heater heater)
        {
            _heater = heater;
        }

        public void Ukljuci()
        {
            if (!_heater.Ukljucen)
            {
                _heater.Ukljucen = true;
                _repository.AzurirajPocetakRada(DateTime.Now);
            }
        }
	}
}

