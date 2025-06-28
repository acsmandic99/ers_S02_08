using System;
using Domain.Constants;
using Domain.Models;
using Domain.Repozitorijumi.HeaterRepozitorijum;
using Domain.Services;
using Presentation;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicijalizacija domen sloja
            IHeaterService heaterService = new DummyHeaterService(); // Dummy implementacija, definisana van ovog fajla
            IDeviceSaljeTempServis deviceTempService = new DummyDeviceSaljeTempServis(); // Definisana van ovog fajla
            IHeaterRepozitorijum heaterRepo = new HeaterRepozitorijum();
            MenadzerTemperatura tempManager = new MenadzerTemperatura();

            DateTime today = DateTime.Today;
            DateTime pocetakDnevnogRezima = today.AddHours(6);
            DateTime krajDnevnogRezima = today.AddHours(22);
            Regulator regulator = new Regulator(tempManager, pocetakDnevnogRezima, krajDnevnogRezima, 22, 18);

            // Inicijalizacija prezentacionog sloja
            InputManager inputManager = new InputManager();
            DisplayManager displayManager = new DisplayManager();
            CommandHandler commandHandler = new CommandHandler(heaterService, deviceTempService, heaterRepo);
            AppController appController = new AppController(displayManager, inputManager, commandHandler, regulator, tempManager);

            // Pokretanje aplikacije
            appController.Run();
        }
    }
}