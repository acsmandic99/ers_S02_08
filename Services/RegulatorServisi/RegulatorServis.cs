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
            //temp manja ispod trazene dnevne temo
            if(_regulator.TemperaturaMenadzer.IzracunajProsecnuTemperaturu() < _regulator.CiljanaDnevnaTemperatura && _regulator.Rezim == RegulatorRezimRada.Dnevni)
            {

            }
        }
    }
}
