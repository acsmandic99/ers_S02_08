using System;
using Domain.Constants;
using Domain.Models;
using Domain.Services;
using Domain.Repozitorijumi.HeaterRepozitorijum;

namespace Presentation
{
    /// <summary>
    /// Klasa koja obrađuje i izvršava korisničke komande.
    /// Zavisi od servisnih interfejsa za grejač, slanje temperature i repozitorijum rada grejača.
    /// </summary>
    public class CommandHandler
    {
        private readonly IHeaterIskluciService _heaterIskljuciService;
        private readonly IHeaterUkljuciService _haeterUkljuciService;
        private readonly IDeviceSaljeTempServis _deviceTempService;
        private readonly IHeaterRepozitorijum _heaterRepo;

        public CommandHandler(IHeaterIskluciService _heaterIskljuciService, IHeaterUkljuciService _haeterUkljuciService, IDeviceSaljeTempServis deviceTempService, IHeaterRepozitorijum heaterRepo)
        {
            //_heaterIskljuciService = hea;
            _deviceTempService = deviceTempService;
            _heaterRepo = heaterRepo;
        }

        /// <summary>
        /// Na osnovu unete komande izvršava odgovarajuću akciju.
        /// </summary>
        /// <param name="command">Komanda kao string.</param>
        /// <param name="regulator">Instanca regulatora.</param>
        /// <param name="tempManager">Instanca menadžera temperatura.</param>
        public void HandleCommand(string command, Regulator regulator, MenadzerTemperatura tempManager)
        {
            switch (command)
            {
                case "1":
                    SimulateTemperature(tempManager);
                    break;
                case "2":
                    ToggleHeater();
                    break;
                case "3":
                    ShowStatistics();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nepoznata opcija.");
                    break;
            }
        }

        /// <summary>
        /// Simulira merenje temperature, kreira uređaj sa slučajnom temperaturom i evidentira očitanu vrednost.
        /// </summary>
        /// <param name="tempManager">Menadžer za evidentiranje očitanih temperatura.</param>
        private void SimulateTemperature(MenadzerTemperatura tempManager)
        {
            Random rnd = new Random();
            var device = new Device(1, TimeSpan.FromMinutes(RegulatorConstants.IntervalProvereTemperatura));
            device.TrenutnaTemp = rnd.Next((int)RegulatorConstants.MinTemperature, (int)RegulatorConstants.MaxTemperature + 1);
            tempManager.DodajTemperaturu(device.TrenutnaTemp);

            // Ako je definisan servis za slanje temperature, poziva se njegova metoda.
            _deviceTempService?.SaljeVrednost(device);

            Console.WriteLine($"Simulirana temperatura: {device.TrenutnaTemp} °C");
        }

        /// <summary>
        /// Uključuje i zatim isključuje grejač, koristeći servis za grejač.
        /// </summary>
        private void ToggleHeater()
        {
            Console.WriteLine("Prebacivanje grejača...");
            _heaterIskljuciService.Ukljuci();
            System.Threading.Thread.Sleep(1000); // simuliramo kratko trajanje rada
            _heaterService.Iskljuci();
            Console.WriteLine("Grejač je aktiviran i deaktiviran.");
        }

        /// <summary>
        /// Prikazuje statistiku rada grejača, čitanu iz repozitorijuma.
        /// </summary>
        private void ShowStatistics()
        {
            Console.WriteLine("Statistika rada grejača:");
            Console.WriteLine($"Ukupna potrošnja: {_heaterRepo.UkupnaPotrosnja()} jedinica");
            Console.WriteLine($"Ukupno radno vreme: {_heaterRepo.UkupnoRadnoVreme()}");
        }
    }
}