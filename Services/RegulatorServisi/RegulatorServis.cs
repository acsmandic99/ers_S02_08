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
        public double RegulatorProsecnaTemperatura(Regulator r)
        {
            double prosecnaTemperatura = 0;
            for(int i = 0;i<RegulatorConstants.MaxUredjaj;i++)
            {
                prosecnaTemperatura += r.TrenutneTemperature[i];
            }
            return prosecnaTemperatura / RegulatorConstants.MaxUredjaj;
        }
        public void RegulatorSaljeKomande(Regulator regulator, Heater heater)
        {
            double prosecnaTemperatura = RegulatorProsecnaTemperatura(regulator);
            if(regulator.Rezim == RegulatorRezimRada.Dnevni && prosecnaTemperatura < regulator.CiljanaDnevnaTemperatura)
            {
                heater.UkljuciPec();
            }
            else if(regulator.Rezim == RegulatorRezimRada.Nocni && prosecnaTemperatura < regulator.CiljanaNocnaTemperatura)
            {
                heater.UkljuciPec();
            }
            else if(heater.Ukljucen == true && regulator.Rezim == RegulatorRezimRada.Dnevni && prosecnaTemperatura >= regulator.CiljanaDnevnaTemperatura)
            {
                heater.IskljuciPec();
            }
            else if (heater.Ukljucen == true && regulator.Rezim == RegulatorRezimRada.Nocni && prosecnaTemperatura >= regulator.CiljanaNocnaTemperatura)
            {
                heater.IskljuciPec();
            }
        }
    }
}
