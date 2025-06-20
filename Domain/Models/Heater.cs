using Domain.Enums;

namespace Domain.Models
{
    public class Heater
    {
        private bool Ukljucen { get; set; }
        private HeaterRezimRada RezimRada { get; set; }
        
        public void UkljuciPec()
        {
            Ukljucen = true;
        }
        public void IskljuciPec()
        {
            Ukljucen = false;
        }

        public Heater()
        {
            Ukljucen = false;
            RezimRada = HeaterRezimRada.HIGH;
        }
    }
}
