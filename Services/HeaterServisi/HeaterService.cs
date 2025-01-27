using Domain.Models;
using Domain.Repozitorijumi.HeaterRepozitorijum;
using Domain.Services;
namespace Services.HeaterServisi
{
    public class HeaterService : IHeaterService
    {
        private readonly Heater _heater;
        private readonly IHeaterRepozitorijum _repository;

        public HeaterService(Heater heater, IHeaterRepozitorijum repository)
        {
            _heater = heater;
            _repository = repository;
        }

        public void Ukljuci()
        {
            if (!_heater.Ukljucen)
            {
                _heater.UkljuciPec();
                _repository.AzurirajPocetakRada(DateTime.Now);
            }
        }

        public void Iskljuci()
        {
            if (_heater.Ukljucen)
            {
                _heater.IskljuciPec();
                var vremeKraja = DateTime.Now;
                var trajanje = vremeKraja - _repository.TrenutniPocetakRada().Value;
                var potrosnja = trajanje.TotalHours;

                _repository.AzurirajKrajRada(vremeKraja, potrosnja);
            }
        }

    }
}

