using System;
namespace Presentation.TimeImport
{
	public class TimeImport
	{
		public int StartingTime()
		{
            Console.WriteLine("=== KONFIGURACIJA REGULATORA ===");
            Console.WriteLine("-------------------------------------");
            Console.Write("Unesite početni sat dnevnog režima (0-23): ");
            int start = Int32.Parse(Console.ReadLine());
            if(start < 0 || start > 23)
            {
                Console.WriteLine("[INVALID] Pogresan unos!");
                return StartingTime();
            }

            return start;
        }

        public int EndingTime()
        {
            Console.WriteLine("=== KONFIGURACIJA REGULATORA ===");
            Console.WriteLine("-------------------------------------");
            Console.Write("Unesite krajnji sat dnevnog režima (0-23): ");
            int end = Int32.Parse(Console.ReadLine());
            if (end < 0 || end > 23)
            {
                Console.WriteLine("[INVALID] Pogresan unos!");
                return EndingTime();
            }

            return end;
        }
    }
}

