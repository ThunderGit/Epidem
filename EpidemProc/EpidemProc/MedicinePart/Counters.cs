using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EpidemProc.VirusPart;
using EpidemProc.Region;
using EpidemProc.Models;
using EpidemProc.Enum;
using EpidemProc;

namespace EpidemProc.MedPart
{
	class Counters
	{
		private static float HealthFactor(int status)
		{
			if (Equals(HealthStatus.Healthy, status)) return 1;
			else if (Equals(HealthStatus.Ok, status)) return 0.9f;
			else if (Equals(HealthStatus.MildСold, status)) return 0.5f;
			else if (Equals(HealthStatus.SeriousCold, status)) return 0.3f;
			else return 0;
		}
		private static int DoctorEffective(Doctor doctors, Citizen citizen, int standart)
		{
			int HardWorkerFactor = 1;
			int InitiativeFactor = 1;
			float SickFactor = HealthFactor(citizen.HealthStatus);
			if (citizen.HardWorker) HardWorkerFactor = 2;
			if (doctors.Initiative) InitiativeFactor = 2;
			return Convert.ToInt32(standart * HardWorkerFactor * SickFactor * InitiativeFactor);
		}
		public static int[] CountMaxEffectiveVisitersPerDay(Hospital[] hospitals, Doctor[] doctors, Citizen[] citizens, int standart)
		{
			int[] MaxEffectiveVisitersPerDay = new int[hospitals.Length];
			for (int i = 0; i < hospitals.Length; i++)
			{
				MaxEffectiveVisitersPerDay[i] = 0;
				for (int j = 0; j < doctors.Length; j++)
				{
					if (doctors[j].HospitalId == hospitals[i].Id)
					{
						for (int k = 0; k < citizens.Length; k++)
						{
							if (citizens[k].Id == doctors[j].Id)
							{
								MaxEffectiveVisitersPerDay[i] += DoctorEffective(doctors[j], citizens[k], standart);
								break;
							}
						}
					}
				}
			}
			return MaxEffectiveVisitersPerDay;
		}
		public static int[] CountMaxEffectiveHospitalsPerDay(Hospital[] hospitals)
		{
			int [] MaxEffectiveHospitalsPerDay = new int[hospitals.Length];
			for (int i = 0; i < hospitals.Length; i++)
			{
				MaxEffectiveHospitalsPerDay[i] = hospitals[i].MaxHospitalized * hospitals[i].CorruptionLevel / 100 - hospitals[i].CountOfHospitalized;
			}
			return MaxEffectiveHospitalsPerDay;
		}


	}
}