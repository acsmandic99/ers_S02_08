using System;
using Domain.Models;
using Domain.Repozitorijumi.HeaterRepozitorijum;

namespace Services.HeaterIskljuciServices
{
    public class HeaterIskljuciService
    {
        private readonly Heater _heater;
        private readonly IHeaterRepozitorijum _repository = new HeaterRepozirorijum();

        public HeaterIskljuciService(Heater heater)
        {
            _heater = heater;
        }

        public void Iskljuci()
        {
            if (_heater.Ukljucen)
            {
                _heater.Ukljucen = false;

                var vremeKraja = DateTime.Now;
                var rad = _repository.TrenutniPocetakRada();
                var trajanje = vremeKraja - (rad ?? vremeKraja); // ako je rad null, trajanje je 0
                var potrosnja = trajanje.TotalHours;

                _repository.AzurirajKrajRada(vremeKraja, potrosnja);
            }
        }
    }
}
