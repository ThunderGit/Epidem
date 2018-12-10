using System;
using EpidemProc.LifeSimulator;
using EpidemProc.VirusPart;
using EpidemProc.Region;
using EpidemProc.Models;
using EpidemProc.Enum;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EpidemProc.MedPart;
using EpidemProc.Scientist;
using EpidemProc.MilPart;
using EpidemProc.PolPart;
using EpidemProc.Model.Log;

namespace EpidemProc
{
	class Logger
	{

		private static void Log_Infected(int iter, Citizen[] citizens, Police[] polices,
		Hospital[] hospitals, Millitary[] millitaries, Facture[] factures, Home[] homes)
		{
			LogInfected[] LI = null;
			List<LogInfected> LLI = null;
			
			for (int i = 0; i < polices.Length; i++)
			{
				LLI.Add(new LogInfected
				{
					Id = 0,
					Iteration = iter,
					X = polices[i].X,
					Y = polices[i].Y,
					CountOfHealthy = 0,
					CountOfInfected = 0
				});
			}
			for (int i = 0; i < hospitals.Length; i++)
			{
				LLI.Add(new LogInfected
				{
					Id = 0,
					Iteration = iter,
					X = hospitals[i].X,
					Y = hospitals[i].Y,
					CountOfHealthy = 0,
					CountOfInfected = 0
				});
			}
			for (int i = 0; i < millitaries.Length; i++)
			{
				LLI.Add(new LogInfected
				{
					Id = 0,
					Iteration = iter,
					X = millitaries[i].X,
					Y = millitaries[i].Y,
					CountOfHealthy = 0,
					CountOfInfected = 0
				});
			}
			for (int i = 0; i < factures.Length; i++)
			{
				LLI.Add(new LogInfected
				{
					Id = 0,
					Iteration = iter,
					X = factures[i].X,
					Y = factures[i].Y,
					CountOfHealthy = 0,
					CountOfInfected = 0
				});
			}
			for (int i = 0; i < homes.Length; i++)
			{
				LLI.Add(new LogInfected
				{
					Id = 0,
					Iteration = iter,
					X = homes[i].X,
					Y = homes[i].Y,
					CountOfHealthy = 0,
					CountOfInfected = 0
				});
			}
			LI = LLI.ToArray();
			for (int i = 0; i < citizens.Length; i++)
			{
				for (int j = 0; j < LI.Length; j++)
				{
					if (citizens[i].X == LI[j].X && citizens[i].Y == LI[j].Y)
					{
						if (citizens[i].WasSick) LI[j].CountOfInfected++;
						else LI[j].CountOfHealthy++;
						break;
					}
				}
			}
			for (int j = 0; j < LI.Length; j++)
			{

				LI[j].SaveToDB();
			}
		}
		private static void Log_Global(int iter, int day, int hour, Citizen[] _Citizens, Policeman[] policemen, Doctor[] doctors, Troop[] troops, Weather weather, int status, int researchProgress, int countOfDeath)
		{
			LogGlobal LG = new LogGlobal
			{
				Id = 0,
				Iteration = iter,
				CurrentHour = hour,
				CurrentDay = day,
				RegPopulation = _Citizens.Length,
				CountOfInfected = 0,
				CountOfHealthy = 0,
				CountOfDeath = countOfDeath,
				CountOfPolicemans = policemen.Length,
				CountOfSoldiers = troops.Length,
				CountOfDoctors = doctors.Length,
				Temperature = weather.t,
				 Wet = weather.wet,
				Research = researchProgress,
				RegStatus = status,
			};
			LG.SaveToDB();
		}
		private static void Log_Med_Stat(Citizen[] _Citizens, int iter)
		{
			int countInf = 0;
			int countCrit = 0;
			for (int i = 0; i < _Citizens.Length; i++)
			{
				if (_Citizens[i].SickLeave) countInf++;
				if (_Citizens[i].Hospitalized) countCrit++;
			}
			LogMedStatistic LMS = new LogMedStatistic
			{
				Id = 0,
				Iteration = iter,
				CountOfHealthy = _Citizens.Length - countInf,
				CountOfInfected = countInf,
				CountOfCritical = countCrit
			};
			LMS.SaveToDB();
		}
		private static void Log_Virus(Virus virus, int iter)
		{
			LogVirus LV = new LogVirus
			{
				Id = 0,
				Iteration = iter,
				Difficult = virus.Difficult,
				MinInfectT = virus.MinInfectT,
				MaxInfectT = virus.MaxInfectT,
				MinComfortT = virus.MinComfortT,
				MaxComfortT = virus.MaxComfortT,
				WetProtect = virus.WetProtect,
				skeletonDamaged = virus.skeletonDamaged,
				muscleDamaged = virus.muscleDamaged,
				respiratoryDamaged = virus.respiratoryDamaged,
				circulatoryDamaged = virus.circulatoryDamaged,
				diureticDamaged = virus.diureticDamaged,
				digestiveDamaged = virus.digestiveDamaged,
				nervousDamaged = virus.nervousDamaged,
				reproductiveDamaged = virus.reproductiveDamaged,
				sensoryDamaged = virus.sensoryDamaged,
				lyphaticDamaged = virus.lyphaticDamaged,
				immunityDamaged = virus.immunityDamaged
			};
			LV.SaveToDB();
		}

		public static void Run(Citizen[] _Citizens, Policeman[] P, Doctor[] D, Troop[] T, Police[] _Police,
	Hospital[] _Hospital, Millitary[] _Military, Facture[] _Facture, Home[] _home, int day, int hour, int totalDay, int currentDay,
	int status, int researchProgress, int countOfDeath, int iter, Virus virus, Weather weather, MedicinePart med, Economic Econimic)
		{ 
			
		}
	}
}