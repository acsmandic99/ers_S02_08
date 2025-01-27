using Domain.Enums;

namespace Domain.Models
{
    public class Heater
    {
        private bool ukljucen;
        private HeaterRezimRada rezimRada;

        public bool Ukljucen
        {
            get { return ukljucen; }
            set { ukljucen = value; }
        }
        public HeaterRezimRada RezimRada
        {
            get { return rezimRada; }
            set { rezimRada = value; }
        }

        public void UkljuciPec()
        {
            ukljucen = true;
        }
        public void IskljuciPec()
        {
            ukljucen = false;
        }

        public Heater()
        {
            ukljucen = false;
            rezimRada = HeaterRezimRada.HIGH;
        }
    }
}
