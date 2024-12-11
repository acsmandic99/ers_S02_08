using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Regulator
    {
		private RezimRada rezim;

		public RezimRada Rezim
		{
			get { return rezim; }
			set { rezim = value; }
		}

		private TimeSpan pocetakDnevnogRezima;

		public TimeSpan PocetakDnevnogRezima
		{
			get { return pocetakDnevnogRezima; }
			set { pocetakDnevnogRezima = value; }
		}

		private TimeSpan krajDnevnogRezima;

		public TimeSpan KrajDnevnogRezima
		{
			get { return krajDnevnogRezima; }
			set { krajDnevnogRezima = value; }
		}

		private int ciljanaDnevnaTemperatura;

		public int CiljanaDnevnaTemperatura
		{
			get { return ciljanaDnevnaTemperatura; }
			set { ciljanaDnevnaTemperatura = value; }
		}

		private int ciljanaNocnaTemperatura;

		public int CiljanaNocnaTemperatura
		{
			get { return ciljanaNocnaTemperatura; }
			set { ciljanaNocnaTemperatura = value; }
		}


	}
}
