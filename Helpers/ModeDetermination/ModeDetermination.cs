using System;
using Domain.Enums;

namespace Helpers.ModeDetermination
{
	public class ModeDetermination
	{
		public RegulatorRezimRada Determination(int sDay, int eDay)
		{
			int clockNow = DateTime.Now.Hour;

			if(sDay <= eDay)
			{
				if (clockNow >= sDay && clockNow < eDay)
					return RegulatorRezimRada.DAY;
			}
			else
			{
				if (clockNow >= sDay || clockNow < eDay)
					return RegulatorRezimRada.DAY;
			}

			return RegulatorRezimRada.NIGHT;
		}
	}
}

