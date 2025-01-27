using Domain.Constants;

namespace Helpers.Temperature
{
    public static class GenerisanjeTemperature
    {
        public static double GenerisiTemperaturu(double trenutnaTemp, bool povecaj)
        {
            if (povecaj == true)
            {
                return trenutnaTemp + RegulatorConstants.PovecanjeTemperature;
            }
            else
            {
                //Recemo da na nula dolazi ravnoteze sistema gde nema vise gubitaka toplote
                trenutnaTemp -= RegulatorConstants.PovecanjeTemperature / 10;
                if (trenutnaTemp < 0)
                    trenutnaTemp = 0;
                return trenutnaTemp;
            }
        }
    }
}
