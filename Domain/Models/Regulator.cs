using Domain.Enums;
using Domain.Interfejsi;

namespace Domain.Models
{
    public class Regulator
    {
        public RegulatorRezimRada Rezim { get; set; }
        public DateTime PocetakDnevnogRezima { get; set; }
        public DateTime KrajDnevnogRezima { get; set; }
        public int CiljanaDnevnaTemperatura { get; set; }
        public int CiljanaNocnaTemperatura { get; set; }
        public ITemperaturaMenadzer TemperaturaMenadzer { get; }

        public Regulator(
            ITemperaturaMenadzer temperaturaMenadzer,
            DateTime pocetakDnevnogRezima,
            DateTime krajDnevnogRezima,
            int ciljanaDnevnaTemperatura,
            int ciljanaNocnaTemperatura)
        {
            TemperaturaMenadzer = temperaturaMenadzer;
            PocetakDnevnogRezima = pocetakDnevnogRezima;
            KrajDnevnogRezima = krajDnevnogRezima;
            CiljanaDnevnaTemperatura = ciljanaDnevnaTemperatura;
            CiljanaNocnaTemperatura = ciljanaNocnaTemperatura;

            Rezim = (DateTime.Now >= PocetakDnevnogRezima && DateTime.Now < KrajDnevnogRezima)
                ? RegulatorRezimRada.Dnevni
                : RegulatorRezimRada.Nocni;
        }
    }
}
