namespace Domain.Constants
{
    //konstante za regulator,stavio sam max 4 uredjaja ali da ima mogucnost da se sistem prosiruje dodavanjem novih uredjaja
    //Stavio sam min i max na 16 i 30 jer su to obicne vrednosti koje klima uredjaji imaju 
    public static class RegulatorConstants
    {
        public const int MaxUredjaj = 4;
        public const double MinTemperature = 16.0;
        public const double MaxTemperature = 30.0; //stavljeno double, umesto int, zbog povecanja temperature koje je 0.01
        public const int IntervalProvereTemperatura = 3; // u minutima
        public const double PovecanjeTemperature = 0.01; // na svaka 2 minuta
        public const double SmanjenjeFaktoraTemperature = 0.1; //pre je bilo hardkonodvano na 1/10
    }
}