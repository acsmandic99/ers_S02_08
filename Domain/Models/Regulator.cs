using Domain.Models;
using Domain.Enums;

namespace Domain.Models
{
    public class Regulator
    {
        public int WorkStart { get; set; }
        public int WorkEnd { get; set; }
        public double TemperatureDay { get; set; }
        public double TemperatureNight { get; set; }
        public RegulatorRezimRada Regime { get; set; }

        public Regulator() { }

        public Regulator(int start, int end, double tempDay, double tempNight)
        {
            WorkStart = start;
            WorkEnd = end;
            TemperatureDay = tempDay;
            TemperatureNight = tempNight;
        }

    }
}
