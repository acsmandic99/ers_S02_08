using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.PomocneMetode;

namespace Domain.Models
{
    public class Heater
    {
		private bool ukljucen;
		private HeaterRezimRada rezimRada;

		public HeaterRezimRada RezimRada
		{
			get { return rezimRada; }
			set { rezimRada = value; }
		}
		
		public bool Ukljucen
		{
			get { return ukljucen; }
			set
			{
				if(ukljucen == true)
				{
					var pomocna = new IskljuciPecPomocna();
					ukljucen = pomocna.IskljuciPec(false);
				}
				else
				{
                    var pomocna = new UkljuciPecPomocna();
                    ukljucen = pomocna.UkljuciPec(true);
                }
			}
		}

		private DateTime? trenutakUkljucenja;

		public DateTime TrenutakUkljucenja
        {
            get => (DateTime)trenutakUkljucenja;
            set { trenutakUkljucenja = value; }
        }
        public Heater()
        {
			Ukljucen = false;
			trenutakUkljucenja = null;
			rezimRada = HeaterRezimRada.HIGH;
        }
    }
}
