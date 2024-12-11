using Domain.Constants;
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
		private RegulatorRezimRada rezim;


        private TimeSpan krajDnevnogRezima;
        private TimeSpan pocetakDnevnogRezima;
        private int ciljanaDnevnaTemperatura;
        private int ciljanaNocnaTemperatura;
		private int[] trenutneTemperature = new int[RegulatorConstants.MaxUredjaj];

        public TimeSpan PocetakDnevnogRezima
		{
			get { return pocetakDnevnogRezima; }
			set { pocetakDnevnogRezima = value; }
		}

        public RegulatorRezimRada Rezim
        {
            get { return rezim; }
            set { rezim = value; }
        }

        public TimeSpan KrajDnevnogRezima
		{
			get { return krajDnevnogRezima; }
			set { krajDnevnogRezima = value; }
		}
		public int CiljanaDnevnaTemperatura
		{
			get { return ciljanaDnevnaTemperatura; }
			set { ciljanaDnevnaTemperatura = value; }
		}
		public int CiljanaNocnaTemperatura
		{
			get { return ciljanaNocnaTemperatura; }
			set { ciljanaNocnaTemperatura = value; }
		}

        public Regulator(RegulatorRezimRada rezim, TimeSpan krajDnevnogRezima, TimeSpan pocetakDnevnogRezima, int ciljanaDnevnaTemperatura, int ciljanaNocnaTemperatura)
        {
            this.rezim = rezim;
            this.krajDnevnogRezima = krajDnevnogRezima;
            this.pocetakDnevnogRezima = pocetakDnevnogRezima;
            this.ciljanaDnevnaTemperatura = ciljanaDnevnaTemperatura;
            this.ciljanaNocnaTemperatura = ciljanaNocnaTemperatura;
        }
    }
}
