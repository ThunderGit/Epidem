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
	class MedicinePart
	{
		public int StandartVisitersPerDayForOneDoc;
		public int[] MaxEffectiveVisitersPerDay;

		public MedicinePart()
		{
			StandartVisitersPerDayForOneDoc = 20;
		}


		//расчет посещения
		private float HealthFactor(int status)
		{
			if (Equals(HealthStatus.Healthy, status)) return 1;
			else if (Equals(HealthStatus.Ok, status)) return 0.9f;
			else if (Equals(HealthStatus.MildСold, status)) return 0.5f;
			else if (Equals(HealthStatus.SeriousCold, status)) return 0.3f;
			else return 0;
		}
		private int DoctorEffective(Doctor doctors, Citizen citizen)
		{
			int HardWorkerFactor = 1;
			int InitiativeFactor = 1;
			float SickFactor = HealthFactor(citizen.HealthStatus);
			if (citizen.HardWorker) HardWorkerFactor = 2;
			if (doctors.Initiative) InitiativeFactor = 2;
			return Convert.ToInt32(StandartVisitersPerDayForOneDoc * HardWorkerFactor * SickFactor * InitiativeFactor);
		}
		public void CountMaxEffectiveVisitersPerDay(Hospital[] hospitals, Doctor[] doctors, Citizen[] citizens)
		{
			MaxEffectiveVisitersPerDay = new int[hospitals.Length];
			for(int i = 0; i < hospitals.Length; i++)
			{
				MaxEffectiveVisitersPerDay[i] = 0;
				for (int j = 0; j < doctors.Length; j++)
				{
					if(doctors[j].HospitalId == hospitals[i].Id)
					{
						for(int k = 0; k < citizens.Length; k++)
						{
							if(citizens[k].Id == doctors[j].Id)
							{
								MaxEffectiveVisitersPerDay[i] += DoctorEffective(doctors[j], citizens[k]);
								break;
							}
						}
					}
				}
			}
		}



		//посещение 
		private void Invite(ref Citizen patient, ref Hospital[] hospitals, Home[] home)
		{
			for (int i = 0; i < home.Length; i++)
			{
				if (patient.HomeId == home[i].Id)
				{
					for (int j = 0; j < hospitals.Length; j++)
					{
						if(home[i].HospitalId == hospitals[j].Id)
						{
							MaxEffectiveVisitersPerDay[j]--;
							if (0 <= MaxEffectiveVisitersPerDay[j])
							{
								patient.X = hospitals[j].X;
								patient.Y = hospitals[j].Y;
								patient.SickLeave = true;
								hospitals[j].CountOfVisiters++;
								break;
							}
							else
							{
								patient.TrustTheDoctor = 100;
							}
						}
					}
					break;
				}
			}
		}
		//если здоров или ок, то не обращается. Если слабая болезнь но трудоголик то не обращается
		private bool InviteCondition(Citizen patient)
		{
			if ((Equals(patient.HealthStatus, HealthStatus.Critical)
				||
				Equals(patient.HealthStatus, HealthStatus.SeriousCold)
				||
				(Equals(patient.HealthStatus, HealthStatus.MildСold) && !patient.HardWorker)) && patient.WasSick)
			{
				return GeneralOperations.Success(patient.TrustTheDoctor);
			}
			else return false;
		}
		public void Invites(ref Citizen [] patients, ref Hospital [] hospitals, Home [] home)
		{
			for(int i = 0; i < patients.Length; i++)
				if (InviteCondition(patients[i]) && patients[i].WasSick == true)
					Invite(ref patients[i], ref hospitals, home);
		}
	}
}