using System;
using Domain.Models;
namespace Helpers.HeaterHelper
{
	public class HeaterIskljuciHelper
	{
		public HeaterIskljuciHelper(Heater h)
		{
                h.Ukljucen = false;
        }
	}
}

