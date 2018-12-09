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
		public int[] MaxEffectiveHospitalsPerDay;

		public MedicinePart()
		{
			StandartVisitersPerDayForOneDoc = 20;
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

		public void Invites(ref Citizen [] patients, ref Hospital [] hospitals, Home [] home, Doctor [] doctor)
		{
			MaxEffectiveVisitersPerDay = Counters.CountMaxEffectiveVisitersPerDay(hospitals, doctor, patients, StandartVisitersPerDayForOneDoc);
			for (int i = 0; i < patients.Length; i++)
				if (Conditions.InviteCondition(patients[i]) && patients[i].WasSick == true)
					Invite(ref patients[i], ref hospitals, home);
		}

		//госпитализация
		private void Hospitalization(ref Citizen patient, ref Hospital[] hospitals, Home[] home)
		{
			for (int i = 0; i < home.Length; i++)
			{
				if (patient.HomeId == home[i].Id)
				{
					for (int j = 0; j < hospitals.Length; j++)
					{
						if (home[i].HospitalId == hospitals[j].Id)
						{
							MaxEffectiveHospitalsPerDay[j]--;
							if (0 < MaxEffectiveHospitalsPerDay[j])
							{
								patient.X = hospitals[j].X;
								patient.Y = hospitals[j].Y;
								patient.Hospitalized = true;
								hospitals[j].CountOfHospitalized++;
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
		public void Hospitalizations(ref Citizen[] patients, ref Hospital[] hospitals, Home[] home)
		{
			MaxEffectiveHospitalsPerDay = Counters.CountMaxEffectiveHospitalsPerDay(hospitals);
			for (int i = 0; i < patients.Length; i++)
				if (Conditions.HospitalizeCondition(patients[i]) && patients[i].WasSick == true)
					Hospitalization(ref patients[i], ref hospitals, home);
		}



		//покинуть госпиталь
		private void LeaveHospital(ref Citizen patient, ref Hospital[] hospitals, Home[] home)
		{
			for (int i = 0; i < home.Length; i++)
			{
				if (patient.HomeId == home[i].Id)
				{
					for (int j = 0; j < hospitals.Length; j++)
					{
						if (home[i].HospitalId == hospitals[j].Id)
						{
							patient.Hospitalized = false;
							hospitals[j].CountOfHospitalized--;
							break;
						}
					}
				}
				break;
			}
		}
		public void LeavesHospital(ref Citizen[] patients, ref Hospital[] hospitals, Home[] home)
		{
			for (int i = 0; i < patients.Length; i++)
				if (patients[i].Hospitalized == true && !Equals(patients[i].Health, HealthStatus.Critical))
					LeaveHospital(ref patients[i], ref hospitals, home);

		}
	}
}