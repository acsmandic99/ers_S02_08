using Domain.Constants;

namespace Domain.Models
{
    public class Device
    {
        public int IdDevice { get; set; }
        private double TrenutnaTemp { get; set; }
        private TimeSpan IntervalMerenja { get; set; }//Radi jednostavnosti recimo da je ovo deo njegove specifikacije pa mu je zato mesto ovde
        

        public Device(int idDevice, TimeSpan intervalMerenja)
        {
            //TO DO: Osigurati da bude Jedinstveni ID
            IdDevice = idDevice;
            IntervalMerenja = intervalMerenja;
            TrenutnaTemp = RegulatorConstants.MinTemperature;
        }

    }
}
