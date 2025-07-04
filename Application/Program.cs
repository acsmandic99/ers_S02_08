using System;
using Domain.Models;
using Domain.Services;
using Domain.Repositories.DeviceRepositories;
using Services.DeviceServices;
using Services.HeaterServices;
using Services.LoggerServices;
using Services.RegulatorServices;
using Helpers.AverageTemperature;
using Presentation.TimeImport;
using Presentation.ImportTemperature;
using Helpers.ModeDetermination;
using Presentation;
using Domain.Enums;

namespace Application
{
    internal class Program
    {
        private static async Task ControlLoopAsync(IRegulatorService regServ, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                regServ.StartHeating();
                regServ.StopHeating();
                await Task.Delay(TimeSpan.FromSeconds(30), token);
            }
        }

        private static async Task UpdateDeviceTempsAsync(RegulatorService regServ, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                while(!token.IsCancellationRequested)
                {
                    regServ.GetTemps();
                    Console.WriteLine("Task se pokrece.");
                    await Task.Delay(TimeSpan.FromSeconds(10), token);
                }
                
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("=== SMART THERMOREGULATOR ===");

            var opsegUnos = new TimeImport();
            var tempUnos = new ImportTemperature();
            var rezimHelper = new ModeDetermination();

            int startSat = opsegUnos.StartingTime();
            int endSat = opsegUnos.EndingTime();
            double tempDan = tempUnos.TemperatureDay();
            double tempNoc = tempUnos.TemperatureNight();

            var trenutniRezim = rezimHelper.Determination(startSat, endSat);
            Console.WriteLine($"Trenutni rezim je: {rezimHelper.Determination(startSat, endSat)}");

            var regulator = RegulatorFactory.Create(startSat, endSat, tempDan, tempNoc, trenutniRezim);

            // BACKEND SERVISI
            Heater heater = new Heater();
            ILoggerService logger = new LoggerService();
            IDeviceRepository deviceRepo = new DeviceRepository();
            IDeviceService deviceService = new DeviceService(deviceRepo, logger);
            IHeaterService heaterService = new HeaterService(heater, logger);
            var avgHelper = new AverageTemperature();

            IRegulatorService regulatorService = new RegulatorService(deviceService, heaterService, regulator, avgHelper);

            // POKRETANJE
            CancellationTokenSource cts = new CancellationTokenSource();
            Task.Run(() => ControlLoopAsync((RegulatorService)regulatorService, cts.Token));
            Task.Run(() => UpdateDeviceTempsAsync((RegulatorService)regulatorService, cts.Token));

            Console.WriteLine("=== Sistem pokrenut ===");
            Console.ReadLine();
            cts.Cancel();

            /*ILoggerService logger = new LoggerService();
            Heater heater = new Heater();

            IDeviceRepository deviceRepository = new DeviceRepository();

            IDeviceService deviceService = new DeviceService(deviceRepository, logger);
            IHeaterService heaterService = new HeaterService(heater, logger);

            AverageTemperature averageHelper = new AverageTemperature();

            Console.WriteLine("=== KONFIGURACIJA REGULATORA ===");

            Console.Write("Unesite početni sat dnevnog režima (0-23): ");
            int workStart = int.Parse(Console.ReadLine()!);

            Console.Write("Unesite krajnji sat dnevnog režima (0-23): ");
            int workEnd = int.Parse(Console.ReadLine()!);

            Console.Write("Unesite ciljnu dnevnu temperaturu: ");
            double tempDay = double.Parse(Console.ReadLine()!);

            Console.Write("Unesite ciljnu noćnu temperaturu: ");
            double tempNight = double.Parse(Console.ReadLine()!);

            var regulator = new Regulator
            {
                WorkStart = workStart,
                WorkEnd = workEnd,
                TemperatureDay = tempDay,
                TemperatureNight = tempNight,
                //Regime = Domain.Enums.RegulatorRezimRada.DAY
            };

            IEnumerable<double> devTemps = Enumerable.Empty<double>();

            IRegulatorService regulatorService = new RegulatorService(
                deviceService,
                heaterService,
                regulator,
                devTemps,
                averageHelper
                );
            

            var appController = new AppController(
                regulator,
                deviceService,
                heaterService,
                regulatorService,
                logger
            );

            appController.Run();*/
        }
    }
}
