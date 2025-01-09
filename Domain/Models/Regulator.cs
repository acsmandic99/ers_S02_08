using Domain.Constants;
using Domain.Enums;
using Domain.Interfejsi;
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
        private readonly ITemperaturaMenadzer _temperaturaMenadzer;
        int index = 0;


        public ITemperaturaMenadzer TemperaturaMenadzer => _temperaturaMenadzer;
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


        public Regulator(DateTime pocetakDnevnogRezima, DateTime krajDnevnogRezima, int ciljanaDnevnaTemperatura, int ciljanaNocnaTemperatura)
        {
            this.krajDnevnogRezima = krajDnevnogRezima;
            this.pocetakDnevnogRezima = pocetakDnevnogRezima;
            this.ciljanaDnevnaTemperatura = ciljanaDnevnaTemperatura;
            this.ciljanaNocnaTemperatura = ciljanaNocnaTemperatura;
            DateTime trenutnoVreme = DateTime.Now;
            this._temperaturaMenadzer = new MenadzerTemperatura();


            if (trenutnoVreme >= pocetakDnevnogRezima && trenutnoVreme < krajDnevnogRezima)
            {
                rezim = RegulatorRezimRada.Dnevni;
            }
            else
            {
                rezim = RegulatorRezimRada.Nocni;
            }
        }
        public Regulator(ITemperaturaMenadzer tempMenadzer,DateTime pocetakDnevnogRezima, DateTime krajDnevnogRezima, int ciljanaDnevnaTemperatura, int ciljanaNocnaTemperatura)
        {
            this.krajDnevnogRezima = krajDnevnogRezima;
            this.pocetakDnevnogRezima = pocetakDnevnogRezima;
            this.ciljanaDnevnaTemperatura = ciljanaDnevnaTemperatura;
            this.ciljanaNocnaTemperatura = ciljanaNocnaTemperatura;
            DateTime trenutnoVreme = DateTime.Now;
            this._temperaturaMenadzer = tempMenadzer;


            if (trenutnoVreme >= pocetakDnevnogRezima && trenutnoVreme < krajDnevnogRezima)
            {
                rezim = RegulatorRezimRada.Dnevni;
            }
            else
            {
                rezim = RegulatorRezimRada.Nocni;
            }
        }
    }
}
