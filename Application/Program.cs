
using Domain;
using Domain.Models;
using Domain.Enums;
using Helpers;
using Helpers.RegulatorHelpers;
using Services.TemperaturaServisi;
using Domain.Services;

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
            Console.WriteLine($"Kraj dnevnog {krajDnevnogRezima}");
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt);
            Device d1 = new Device(1,span);
            Device d2 = new Device(2,span);
            Device d3 = new Device(3,span);
            Device d4 = new Device(4,span);

            MenadzerTemperatura MT = new MenadzerTemperatura();
            IDeviceSaljeTempServis slanjeTemperatureServis = new SlanjeTemperatureServis(MT);
            slanjeTemperatureServis.SaljeVrednost(d1);
            slanjeTemperatureServis.SaljeVrednost(d2);
            slanjeTemperatureServis.SaljeVrednost(d3);
            slanjeTemperatureServis.SaljeVrednost(d4);



            Regulator r = new Regulator(pocetakDnevnogRezima, krajDnevnogRezima, 22, 18);
            RegulatorPromenaRezima.PromenaRezimaNoviThread(r);
            Console.WriteLine(r.Rezim.ToString());
            TimeSpan interval = krajDnevnogRezima - pocetakDnevnogRezima;
            Console.WriteLine($"Interval :{interval}");
            Console.WriteLine("Test123");
            Console.WriteLine("Test123");
            Console.WriteLine("Test123");
            Console.WriteLine("Test123");
            while(true)
            {
                int x;
                Console.WriteLine("Upisi broj");
                x = Int32.Parse(Console.ReadLine());
            }
            Console.ReadLine();
        }
    }
}
