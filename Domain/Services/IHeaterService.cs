using System;
namespace Domain.Services
{
	public interface IHeaterService
	{
		public bool TurnOff();
		public bool TurnOn();
		public bool IsActive();
	}
}

