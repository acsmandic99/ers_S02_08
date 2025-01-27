using Domain.Constants;

namespace Domain.Models
{
    public class Device
    {
        public int IdDevice { get; set; }
        private double trenutnaTemp;
        private TimeSpan intervalMerenja;//Radi jednostavnosti recimo da je ovo deo njegove specifikacije pa mu je zato mesto ovde
        public double TrenutnaTemp
        {
            get { return trenutnaTemp; }
            set { trenutnaTemp = value; }
        }
        public TimeSpan IntervalMerenja
        {
            get { return intervalMerenja; }
            set { intervalMerenja = value; }
        }

        public Device()
        {

        }

        public Device(int idDevice, TimeSpan intervalMerenja)
        {
            //TO DO: Osigurati da bude Jedinstveni ID
            IdDevice = idDevice;
            this.intervalMerenja = intervalMerenja;
            TrenutnaTemp = RegulatorConstants.MinTemperature;
        }

    }
}
