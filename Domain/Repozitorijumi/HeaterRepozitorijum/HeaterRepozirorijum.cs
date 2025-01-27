namespace Domain.Repozitorijumi.HeaterRepozitorijum
{
    public class HeaterRepozirorijum : IHeaterRepozitorijum
    {

        private DateTime? _pocetakRada;
        private TimeSpan _ukupnoRadnoVreme;
        private double _ukupnaPotrosnja;

        public void AzurirajPocetakRada(DateTime vremePocetka)
        {
            _pocetakRada = vremePocetka;
        }

        public void AzurirajKrajRada(DateTime vremeKraja, double potrosnjaResursa)
        {
            if (_pocetakRada.HasValue)
            {
                var trajanje = vremeKraja - _pocetakRada.Value;
                _ukupnoRadnoVreme += trajanje;
                _ukupnaPotrosnja += potrosnjaResursa;
                _pocetakRada = null;
            }
        }

        public double UkupnaPotrosnja()
        {
            return _ukupnaPotrosnja;
        }

        public TimeSpan UkupnoRadnoVreme()
        {
            return _ukupnoRadnoVreme;
        }

        public DateTime? TrenutniPocetakRada()
        {
            return _pocetakRada;
        }
    }
}

