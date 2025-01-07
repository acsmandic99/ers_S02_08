using Domain.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Constants;
namespace Domain.Models
{
    //Kako regulator ne bi morao da brine o implementaciji cuvanja temperatura sto salju Deviceovi to cemo raditi ovde
    public class MenadzerTemperatura : ITemperaturaMenadzer
    {
        private int[] temperature = new int[RegulatorConstants.MaxUredjaj];
        int idx = 0;
        void ITemperaturaMenadzer.DodajTemperaturu(int novaTemperatura)
        {
            temperature[idx] = novaTemperatura;
            idx++;
            if (idx == 4)
                idx = 0;
        }

        double ITemperaturaMenadzer.IzracunajProsecnuTemperaturu()
        {
            double suma = 0;
            for(int i = 0;i<RegulatorConstants.MaxUredjaj;i++)
            {
                suma += temperature[i];
            }
            return (suma / RegulatorConstants.MaxUredjaj);
        }
    }
}
