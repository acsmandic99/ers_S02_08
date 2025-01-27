using Domain.Models;
using Domain.Repozitorijumi.HeaterRepozitorijum;
using Domain.Services;
namespace Services.HeaterServisi
{
    public class HeaterService : IHeaterService
    {
        private readonly Heater _heater;
        private readonly IHeaterRepozitorijum _repository = new HeaterRepozirorijum();

        public HeaterService(Heater heater)
        {
            _heater = heater;
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
                var rad = _repository.TrenutniPocetakRada();
                var trajanje = vremeKraja - (rad == null ? DateTime.Now : rad.Value);
                var potrosnja = trajanje.TotalHours;

                _repository.AzurirajKrajRada(vremeKraja, potrosnja);
            }
        }

    }
}

