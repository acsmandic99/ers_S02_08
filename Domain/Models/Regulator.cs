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


        private DateTime krajDnevnogRezima;
        private DateTime pocetakDnevnogRezima;
        private int ciljanaDnevnaTemperatura;
        private int ciljanaNocnaTemperatura;
		private int[] trenutneTemperature = new int[RegulatorConstants.MaxUredjaj];
        int index = 0;

        public int[] TrenutneTemperature
        {
            get { return trenutneTemperature; }
            set { trenutneTemperature = value; }
        }
        public DateTime PocetakDnevnogRezima
		{
			get { return pocetakDnevnogRezima; }
			set { pocetakDnevnogRezima = value; }
		}

        public RegulatorRezimRada Rezim
        {
            get { return rezim; }
            set { rezim = value; }
        }

        public DateTime KrajDnevnogRezima
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

        public void DodajTrenutnuTemperaturu(int temperatura)
        {
            trenutneTemperature[index] = temperatura;
            index++;
            if (index == RegulatorConstants.MaxUredjaj)
                index = 0;
        }

        public Regulator(DateTime pocetakDnevnogRezima, DateTime krajDnevnogRezima, int ciljanaDnevnaTemperatura, int ciljanaNocnaTemperatura)
        {
            this.krajDnevnogRezima = krajDnevnogRezima;
            this.pocetakDnevnogRezima = pocetakDnevnogRezima;
            this.ciljanaDnevnaTemperatura = ciljanaDnevnaTemperatura;
            this.ciljanaNocnaTemperatura = ciljanaNocnaTemperatura;
            DateTime trenutnoVreme = DateTime.Now;


            if (trenutnoVreme >= pocetakDnevnogRezima && trenutnoVreme < krajDnevnogRezima)
            {
                rezim = RegulatorRezimRada.Dnevni;
            }
            else
            {
                rezim = RegulatorRezimRada.Nocni;
            }
            for (int i = 0; i < RegulatorConstants.MaxUredjaj; i++) 
            {
                if (rezim == RegulatorRezimRada.Nocni)
                    trenutneTemperature[i] = ciljanaNocnaTemperatura;
                else
                    trenutneTemperature[i] = ciljanaDnevnaTemperatura;
            }
        }
    }
}
