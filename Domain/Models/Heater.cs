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

		public bool Ukljucen
		{
			get { return ukljucen; }
			set { ukljucen = value;}
		}
		public HeaterRezimRada RezimRada
		{
			get { return rezimRada; }
			set { rezimRada = value; }
		}
		
		public void Ukljuci()
		{
			ukljucen = true;
		}
		public void Iskljuci()
		{
			ukljucen = false;
		}

        public Heater()
        {
			ukljucen = false;
			rezimRada = HeaterRezimRada.HIGH;
        }
    }
}
