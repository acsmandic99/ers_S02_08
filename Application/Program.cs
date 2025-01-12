
using Domain;
using Domain.Models;
using Domain.Enums;
using Helpers;
using Helpers.RegulatorHelpers;
using Services.TemperaturaServisi;
using Domain.Services;
using Domain.Interfejsi;
using Services.RegulatorServisi;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Testiram,posle cemo obrisati ovo
            TimeSpan span = TimeSpan.FromSeconds(10);

            DateTime pocetakDnevnogRezima = DateTime.Today.AddHours(20);
            pocetakDnevnogRezima = pocetakDnevnogRezima.AddMinutes(18);
            DateTime krajDnevnogRezima = DateTime.Today.AddHours(22);
            krajDnevnogRezima = krajDnevnogRezima.AddMinutes(54);
            //Console.WriteLine($"Kraj dnevnog {krajDnevnogRezima}");
            DateTime dt = DateTime.Now;
            //Console.WriteLine(dt);
            Heater heater = new Heater();
            ITemperaturaMenadzer MT = new MenadzerTemperatura();
            IDeviceSaljeTempServis slanjeTemperatureServis = new SlanjeTemperatureServis(MT,heater);
            Regulator r = new Regulator(MT, pocetakDnevnogRezima, krajDnevnogRezima, 22, 18);
            RegulatorPromenaRezima.PromenaRezimaNoviThread(r);
            Device d1 = new Device(1,TimeSpan.FromMilliseconds(500));
            Device d2 = new Device(2, TimeSpan.FromMilliseconds(470));
            Device d3 = new Device(3, TimeSpan.FromMilliseconds(350));
            Device d4 = new Device(4, TimeSpan.FromMilliseconds(220));

            
            slanjeTemperatureServis.SaljeVrednost(d1);
            slanjeTemperatureServis.SaljeVrednost(d2);
            slanjeTemperatureServis.SaljeVrednost(d3);
            slanjeTemperatureServis.SaljeVrednost(d4);

            IRegulatorKomandujeHeater regulatorServis = new RegulatorServis(r, heater);

            Thread t1 = new Thread(() =>
            {
                while (true)
                {
                    regulatorServis.RegulatorSaljeKomande();
                    Thread.Sleep(4999);
                }
            });
            t1.Start();

            Thread t = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine($"Prosecna temp {MT.IzracunajProsecnuTemperaturu()}");
                    Thread.Sleep(5000); 
                }
            }
            );
            t.Start();
            Console.ReadLine();
        }
    }
}
