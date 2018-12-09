using System;
using EpidemProc.Models;
using EpidemProc.Region;

namespace EpidemProc.VirusPart
{
	class InfectCondition
	{
		public static bool Condition(Weather weather, Citizen ppatient, int status, Virus virus)
		{
			int statusFactor = InfectFactors.StatusFactor(status);
			int wetFactor = InfectFactors.WetFactor(weather, virus.WetProtect);
			int temperatureFactor = InfectFactors.TemperatureFactor(weather, virus.CoefDifficultInfectDuringUncomfort, virus.MinInfectT, virus.MaxInfectT);
			int imunityFactor = InfectFactors.ImmunityFactor(ppatient.Immunity);

			float probability = (3 * imunityFactor + wetFactor + temperatureFactor + statusFactor) / 6;
			if (GeneralOperations.Success(probability))
				return true;
			else
				return false;
		}

		public static bool PathCondition(Citizen ppatient, Citizen rpatient, Virus virus)
		{
			return Math.Abs((ppatient.X / 20 - rpatient.X / 20)) <= virus.DangerInfectRadius &&
				Math.Abs((ppatient.Y / 20 - rpatient.Y / 20)) <= virus.DangerInfectRadius;
		}
	}
}