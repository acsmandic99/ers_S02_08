using Domain.Enums;
using Domain.Models;
using Domain.Services;

namespace Services.RegulatorServisi
{
    public class RegulatorServis : IRegulatorKomandujeHeater
    {
        private readonly Regulator _regulator;
        private readonly Heater _heater;
        IIspisService _ispisService;

        public RegulatorServis(Regulator regulator, Heater heater, IIspisService ispisService)
        {
            _regulator = regulator;
            _heater = heater;
            _ispisService = ispisService;
        }

        public void RegulatorSaljeKomande()
        {
            if (_heater.Ukljucen == false && _regulator.TemperaturaMenadzer.IzracunajProsecnuTemperaturu() < _regulator.CiljanaDnevnaTemperatura && _regulator.Rezim == RegulatorRezimRada.Dnevni)
            {
                _ispisService.Ispisi("Ukljucujemo pec preko dana jer smo ispod trazene temp");
                _heater.UkljuciPec();//napraiviti servis za heter i repozitorijum gde ces implementirati ono za vremenski trenutak
            }
            else if (_heater.Ukljucen == true && _regulator.TemperaturaMenadzer.IzracunajProsecnuTemperaturu() >= _regulator.CiljanaDnevnaTemperatura && _regulator.Rezim == RegulatorRezimRada.Dnevni)
            {
                _ispisService.Ispisi("Dostigli smo traznu temp iskljucujemo pec");
                _heater.IskljuciPec();
            }
            else if (_heater.Ukljucen == false && _regulator.TemperaturaMenadzer.IzracunajProsecnuTemperaturu() < _regulator.CiljanaNocnaTemperatura && _regulator.Rezim == RegulatorRezimRada.Nocni)
            {
                _ispisService.Ispisi("Ukljucujemo pec preko noci jer smo ispod trazene temp");
                _heater.UkljuciPec();
            }
            else if (_heater.Ukljucen == true && _regulator.TemperaturaMenadzer.IzracunajProsecnuTemperaturu() >= _regulator.CiljanaNocnaTemperatura && _regulator.Rezim == RegulatorRezimRada.Nocni)
            {
                _ispisService.Ispisi("Dostigli smo traznu temp iskljucujemo pec");
                _heater.IskljuciPec();
            }
        }
    }
}
