using Domain.Interfejsi;
using Domain.Models;
using Domain.Services;
using Helpers.Temperature;

namespace Services.TemperaturaServisi
{
    public class SlanjeTemperatureServis : IDeviceSaljeTempServis
    {
        private readonly ITemperaturaMenadzer _temperaturaMenadzer;
        private readonly Heater _heater;

        public SlanjeTemperatureServis(ITemperaturaMenadzer temperaturaMenadzer, Heater heater)
        {
            _temperaturaMenadzer = temperaturaMenadzer;
            _heater = heater;
        }

        public void SaljeVrednost(Device device)
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    if (_heater.Ukljucen == true)
                        device.TrenutnaTemp = GenerisanjeTemperature.GenerisiTemperaturu(device.TrenutnaTemp, true);
                    else
                        device.TrenutnaTemp = GenerisanjeTemperature.GenerisiTemperaturu(device.TrenutnaTemp, false);
                    _temperaturaMenadzer.DodajTemperaturu(device.TrenutnaTemp);
                    Console.WriteLine($"Device poslao {device.TrenutnaTemp}");
                    Thread.Sleep(device.IntervalMerenja);
                }
            });
            thread.Start();
        }
    }
}
