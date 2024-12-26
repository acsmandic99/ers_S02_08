using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services.RegulatorServisi
{
    public class RegulatorDeviceServis : IDeviceSaljeTempServis
    {
        public void SaljeVrednost(Device device, Regulator regulator)
        {
            regulator.DodajTrenutnuTemperaturu(device.TrenutnaTemp);
        }
    }
}
