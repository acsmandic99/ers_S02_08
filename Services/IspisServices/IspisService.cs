using Domain.Services;

namespace Services.IspisServices
{
    public class IspisService : IIspisService
    {
        public void Ispisi(string s)
        {
            Console.WriteLine(s);
        }
    }
}
