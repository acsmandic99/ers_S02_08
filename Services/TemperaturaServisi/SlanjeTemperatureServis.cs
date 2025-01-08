using Domain.Interfejsi;
using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TemperaturaServisi
{
    public class SlanjeTemperatureServis : IDeviceSaljeTempServis
    {
        private readonly ITemperaturaMenadzer _temperaturaMenadzer;

        public SlanjeTemperatureServis(ITemperaturaMenadzer temperaturaMenadzer)
        {
            _temperaturaMenadzer = temperaturaMenadzer;
        }

        public void SaljeVrednost(Device device)
        {
            Random random = new Random();
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    //TO DO: smisliti koje vrednosti da salju device-ovi 
                    device.TrenutnaTemp = random.Next(10, 20);
                    _temperaturaMenadzer.DodajTemperaturu(device.TrenutnaTemp);
                    Console.WriteLine($"Device poslao {device.TrenutnaTemp}");
                    Thread.Sleep(device.IntervalMerenja);
                }
            });
            thread.Start();
        }
    }
}
