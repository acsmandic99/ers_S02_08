using System;
using Domain.Models;


namespace Presentation
{
    /// <summary>
    /// Klasa koja se brine za prikaz zaglavlja, menija i pauziranje interfejsa.
    /// </summary>
    public class DisplayManager
    {
        /// <summary>
        /// Prikazuje zaglavlje sistema sa osnovnim informacijama o regulatoru.
        /// </summary>
        /// <param name="regulator">Instanca regulatora.</param>
        public void ShowHeader(Regulator regulator)
        {
            Console.Clear();
            Console.WriteLine("Smart Thermoregulator System");
            Console.WriteLine("=============================");
            Console.WriteLine($"Regulator Mode: {regulator.Rezim}");
            Console.WriteLine($"Target Temp (Day): {regulator.CiljanaDnevnaTemperatura} °C");
            Console.WriteLine($"Target Temp (Night): {regulator.CiljanaNocnaTemperatura} °C");
            Console.WriteLine();
        }

        /// <summary>
        /// Prikazuje meni sa dostupnim opcijama.
        /// </summary>
        public void ShowMenu()
        {
            Console.WriteLine("Opcije:");
            Console.WriteLine("1. Simuliraj merenje temperature");
            Console.WriteLine("2. Prebaci grejač (uključi/isključi)");
            Console.WriteLine("3. Prikaži statistiku grejača");
            Console.WriteLine("4. Izlaz");
        }

        /// <summary>
        /// Pauzira prikaz i čeka da korisnik pritisne taster.
        /// </summary>
        /// <param name="message">Poruka korisniku.</param>
        public void Pause(string message = "Pritisnite bilo koji taster za nastavak...")
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
