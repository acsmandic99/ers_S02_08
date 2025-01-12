using System;
namespace Domain.Repozitorijumi.HeaterRepozitorijum
{
	public interface IHeaterRepozitorijum
	{
        void AzurirajPocetakRada(DateTime vremePocetka);
        void AzurirajKrajRada(DateTime vremeKraja, double potrosnjaResursa);
        double UkupnaPotrosnja();
        TimeSpan UkupnoRadnoVreme();
        DateTime? TrenutniPocetakRada();
    }
}

