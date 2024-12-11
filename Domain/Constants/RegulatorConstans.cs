namespace Domain.Constants
{
    //konstante za regulator,stavio sam max 4 uredjaja ali da ima mogucnost da se sistem prosiruje dodavanjem novih uredjaja
    //Stavio sam min i max na 16 i 30 jer su to obicne vrednosti koje klima uredjaji imaju 
    public static class RegulatorConstants
    {
        public const int MaxUredjaj = 4;
        public const int MinTemperature = 16;
        public const int MaxTemperature = 30;
    }

}