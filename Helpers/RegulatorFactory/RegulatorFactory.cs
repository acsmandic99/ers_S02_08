using Domain.Models;
using Domain.Enums;

public static class RegulatorFactory
{
    public static Regulator Create(int pocetak, int kraj, double dnevna, double nocna, RegulatorRezimRada rezim)
    {
        return new Regulator
        {
            WorkStart = pocetak,
            WorkEnd = kraj,
            TemperatureDay = dnevna,
            TemperatureNight = nocna,
            Regime = rezim
        };
    }
}
