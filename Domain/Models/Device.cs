using Domain.Constants;

namespace Domain.Models
{
    public class Device
    {
        public int IdDevice { get; set; }
        public double TempNow { get; set; }

        public Device() { }

        public Device(int idDevice, double tempDevice)
        {
            IdDevice = idDevice;
            TempNow = tempDevice;
        }

    }
}
