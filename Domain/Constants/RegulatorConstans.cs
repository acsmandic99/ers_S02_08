namespace Domain.Constants
{
    public static class RegulatorConstants
    {
        public const int MinDevice = 4;
        public const double MinTemperature = 16.0;
        public const double MaxTemperature = 30.0; //stavljeno double, umesto int, zbog povecanja temperature koje je 0.01
        public const int IntervalProvereTemperatura = 3; // u minutima
        public const double TempUp = 0.01; // na svaka 2 minuta
        public const double TempDown = 0.1; //pre je bilo hardkonodvano na 1/10
    }
}