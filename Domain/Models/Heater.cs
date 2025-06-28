using Domain.Enums;

namespace Domain.Models
{
    public class Heater
    {
        public bool Ukljucen { get; set; }
        private HeaterRezimRada RezimRada { get; set; }

        public Heater()
        {
            Ukljucen = false;
            RezimRada = HeaterRezimRada.HIGH;
        }
    }
}
