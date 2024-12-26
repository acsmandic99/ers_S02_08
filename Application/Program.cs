
using Domain;
using Domain.Models;
using Domain.Enums;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Testiram,posle cemo obrisati ovo
            TimeSpan span = TimeSpan.FromSeconds(10);
            TimeSpan dnevniP = new TimeSpan(8, 0, 0);
            TimeSpan dnevniK = new TimeSpan(20, 0, 0);


            DateTime dt = DateTime.Now;
            Console.WriteLine(dt);
            Console.WriteLine(span);
            Device d1 = new Device(1,span);
            Device d2 = new Device(2,span);
            Device d3 = new Device(3,span);
            Device d4 = new Device(4,span);
            Regulator r = new Regulator(RegulatorRezimRada.Dnevni, dnevniK, dnevniP, 22, 19);
            Console.WriteLine("Test123");
            Console.ReadLine();
        }
    }
}
