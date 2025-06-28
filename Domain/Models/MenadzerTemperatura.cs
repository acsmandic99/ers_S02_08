using Domain.Constants;
using Domain.Interfejsi;

namespace Domain.Models
{
    public class MenadzerTemperatura : ITemperaturaMenadzer
    {
        private readonly double[] _temperature;
        private int _index;

        public MenadzerTemperatura()
        {
            _temperature = new double[RegulatorConstants.MaxUredjaj];
            _index = 0;
        }

        public void DodajTemperaturu(double novaTemperatura)
        {
            _temperature[_index] = novaTemperatura;
            _index = (_index + 1) % RegulatorConstants.MaxUredjaj;
        }

        public double IzracunajProsecnuTemperaturu()
        {
            double suma = 0;
            foreach (var t in _temperature)
            {
                suma += t;
            }
            return suma / RegulatorConstants.MaxUredjaj;
        }
    }
}
