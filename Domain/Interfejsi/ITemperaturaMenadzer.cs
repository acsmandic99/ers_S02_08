using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfejsi
{
    public interface ITemperaturaMenadzer
    {
        double IzracunajProsecnuTemperaturu();
        void DodajTemperaturu(double novaTemperatura);
    }
}
