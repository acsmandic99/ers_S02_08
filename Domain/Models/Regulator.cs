using Domain.Enums;
using Domain.Interfejsi;

namespace Domain.Models
{
    public class Regulator
    {
        public RegulatorRezimRada Rezim { get; set; }
        public DateTime KrajDnevnogRezima { get; set; }
        public DateTime PocetakDnevnogRezima { get; set; }
        public int CiljanaDnevnaTemperatura { get; set; }
        public int CiljanaNocnaTemperatura { get; set; }
        public ITemperaturaMenadzer TemperaturaMenadzer { get; }

        public Regulator(DateTime pocetakDnevnogRezima, DateTime krajDnevnogRezima, int ciljanaDnevnaTemperatura, int ciljanaNocnaTemperatura)
        {
            PocetakDnevnogRezima = pocetakDnevnogRezima;
            KrajDnevnogRezima = krajDnevnogRezima;
            CiljanaDnevnaTemperatura = ciljanaDnevnaTemperatura;
            CiljanaNocnaTemperatura = ciljanaNocnaTemperatura;
            DateTime trenutnoVreme = DateTime.Now;
            TemperaturaMenadzer = new MenadzerTemperatura();
            Rezim = (trenutnoVreme >= PocetakDnevnogRezima && trenutnoVreme < KrajDnevnogRezima)
                    ? RegulatorRezimRada.Dnevni
                    : RegulatorRezimRada.Nocni;
        }

        public Regulator(ITemperaturaMenadzer tempMenadzer, DateTime pocetakDnevnogRezima, DateTime krajDnevnogRezima, int ciljanaDnevnaTemperatura, int ciljanaNocnaTemperatura)
        {
            PocetakDnevnogRezima = pocetakDnevnogRezima;
            KrajDnevnogRezima = krajDnevnogRezima;
            CiljanaDnevnaTemperatura = ciljanaDnevnaTemperatura;
            CiljanaNocnaTemperatura = ciljanaNocnaTemperatura;
            DateTime trenutnoVreme = DateTime.Now;
            TemperaturaMenadzer = tempMenadzer;
            Rezim = (trenutnoVreme >= PocetakDnevnogRezima && trenutnoVreme < KrajDnevnogRezima)
                    ? RegulatorRezimRada.Dnevni
                    : RegulatorRezimRada.Nocni;
        }
    }
}
