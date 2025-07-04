using Domain.Enums;

namespace Domain.Models
{
    public class Heater
    {
        public bool IsActive { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TotalWorkingTime { get; set; }
        public double ResorceUsed { get; set; }
    

        public Heater()
        {
            IsActive = false;
            TotalWorkingTime = TimeSpan.Zero;
            ResorceUsed = 0.0;
            
        }

    }
}
