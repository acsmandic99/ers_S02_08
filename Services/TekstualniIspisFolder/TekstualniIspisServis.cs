using System;
using Domain.Services;
using System.Text;
namespace Services.TekstualniIspisFolder
{
	public class TekstualniIspisServis : ITekstualniIspis
	{
		IPripremaZaIspis _priprema;

        public TekstualniIspisServis(IPripremaZaIspis priprema)
		{
			_priprema = priprema;
		}

        public void Ispis()
        {
			StringBuilder sb = _priprema.pripremaText();
			Console.WriteLine(sb);
			using StreamWriter sw = new StreamWriter("Ispis.txt", append:false);
			sw.WriteLine(sb);
        }

		//ispis u tekstualnu datoteku
    }
}

