using Domain.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Constants;
namespace Domain.Models
{
    //Kako regulator ne bi morao da brine o implementaciji cuvanja temperatura sto salju Deviceovi to cemo raditi ovde
    public class MenadzerTemperatura : ITemperaturaMenadzer
    {
        private double[] temperature = new double[RegulatorConstants.MaxUredjaj];
        int idx = 0;
        private static readonly object _lock = new object();
        bool zauzet = false;

        void ITemperaturaMenadzer.DodajTemperaturu(double novaTemperatura)
        {
            /*
                Jako slicno kao iz OS-a sto smo radili sa mutexom i condition variablom samo nam je ovde dosta ovaj _lock
            Monitor.Wait je isto kao sto smo imali na OS-u cv.wait()
            Monitor.PulseAll() nam je slicno kao cv.notify_all()
            a lock je slican kao unique_lock<mutex> l(mtx) u smislu da cim se izadje iz scope-a poziva se destruktor 
            i oslobadja se resurs
            podseti se malo iz OS-a kako to radi ako ne budes razumeo pitaj me
                */
            Monitor.Enter(_lock); //lock
            try
            {
                while (zauzet == true)
                { 
                    //Console.WriteLine("Neko vec pise pa ja cekam");
                    Monitor.Wait(_lock);
                    //Console.WriteLine("Probudio sam se"); 
                }
                zauzet = true;
                //Monitor.PulseAll(_lock);
                //Monitor.Exit(_lock);
                //Thread.Sleep(5000);
                //Monitor.Enter(_lock);
                //Ovo sam je kao neko simuliranje pisanja da vidis sta se desi kada neko pokusa da pise
                //dok druga nit vec upisuje
                temperature[idx] = novaTemperatura;
                idx++;
                if (idx == 4)
                    idx = 0;
                
            }finally
            {
                zauzet = false;
                Monitor.PulseAll(_lock);//notify_all
                Monitor.Exit(_lock);//unlock
            }
        }

        double ITemperaturaMenadzer.IzracunajProsecnuTemperaturu()
        {
            lock(_lock) //zakljucavamo da slucajno ne bi neka nit pisala dok citamo podatke
            {
                double suma = 0;
                for(int i = 0;i<RegulatorConstants.MaxUredjaj;i++)
                {
                    suma += temperature[i];
                }
                return (suma / RegulatorConstants.MaxUredjaj);
            }
        }
    }
}
