using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Device
    {
        public int IdDevice { get; set; }
		private int trenutnaTemp;

		public int TrenutnaTemp
		{
			get { return trenutnaTemp; }
			set { trenutnaTemp = value; }
		}

		private TimeSpan intervalMerenja;//Radi jednostavnosti recimo da je ovo deo njegove specifikacije pa mu je zato mesto ovde

		public TimeSpan IntervalMerenja
		{
			get { return intervalMerenja; }
			set { intervalMerenja = value; }
		}

        public Device(int idDevice,TimeSpan intervalMerenja)
        {
			//TO DO: Osigurati da bude Jedinstveni ID
            IdDevice = idDevice;
            this.intervalMerenja = intervalMerenja;
        }

    }
}
