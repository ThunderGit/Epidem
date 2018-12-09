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

		private static void Log_Infected(long iter, Citizen[] _Citizens, Police[] _Police,
		Hospital[] _Hospital, Millitary[] _Military, Facture[] _Facture, Home[] _home)
		{

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
		}

		public static void Run(Citizen[] _Citizens, Policeman[] P, Doctor[] D, Troop[] T, Police[] _Police,
	Hospital[] _Hospital, Millitary[] _Military, Facture[] _Facture, Home[] _home, int day, int hour, int totalDay, int currentDay,
	int status, int researchProgress, int countOfDeath, int iter, Virus virus, Weather weather, MedicinePart med, Economic Econimic)
		{ 
			
		}
	}
}