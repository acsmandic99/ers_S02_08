using Domain.Constants;
using Domain.Models;
using Domain.Services;
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

        }
    }
}
