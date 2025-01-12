using Domain.Constants;
using Domain.Models;
using Domain.Services;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RegulatorServisi
{
    public class RegulatorServis : IRegulatorKomandujeHeater
    {
        private readonly Regulator _regulator;
        private readonly Heater _heater;

        public RegulatorServis(Regulator regulator, Heater heater)
        {
            _regulator = regulator;
            _heater = heater;
        }

        public void RegulatorSaljeKomande()
        {
            if(_heater.Ukljucen == false && _regulator.TemperaturaMenadzer.IzracunajProsecnuTemperaturu() < _regulator.CiljanaDnevnaTemperatura && _regulator.Rezim == RegulatorRezimRada.Dnevni)
            {
                Console.WriteLine("Ukljucujemo pec preko dana jer smo ispod trazene temp");
                _heater.UkljuciPec();//napraiviti servis za heter i repozitorijum gde ces implementirati ono za vremenski trenutak
            }
            else if(_heater.Ukljucen == true && _regulator.TemperaturaMenadzer.IzracunajProsecnuTemperaturu() >= _regulator.CiljanaDnevnaTemperatura && _regulator.Rezim == RegulatorRezimRada.Dnevni)
            {
                Console.WriteLine("Dostigli smo traznu temp iskljucujemo pec");
                _heater.IskljuciPec();
            }
            else if(_heater.Ukljucen == false && _regulator.TemperaturaMenadzer.IzracunajProsecnuTemperaturu() < _regulator.CiljanaNocnaTemperatura && _regulator.Rezim == RegulatorRezimRada.Nocni)
            {
                Console.WriteLine("Ukljucujemo pec preko noci jer smo ispod trazene temp");
                _heater.UkljuciPec();
            }
            else if(_heater.Ukljucen == true && _regulator.TemperaturaMenadzer.IzracunajProsecnuTemperaturu() >= _regulator.CiljanaNocnaTemperatura && _regulator.Rezim == RegulatorRezimRada.Nocni)
            {
                Console.WriteLine("Dostigli smo traznu temp iskljucujemo pec");
                _heater.IskljuciPec();
            }
        }
    }
}
