using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public void UkljuciPec()
		{
			ukljucen = true;
		}
		public void IskljuciPec()
		{
			ukljucen = false;
		}
		public bool Ukljucen
		{
			get { return ukljucen; }
			set { ukljucen = value; }
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
