using System;
namespace Domain.Services
{
	public interface IRegulatorService
	{
		public IEnumerable<double> GetTemps();
		public void StartHeating();
		public void StopHeating();

    }
}

