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

namespace EpidemProc.Scientist
{
	class ScientistPart
	{
		public static int CoefOfEffective = 250000;
		public static int Research(Hospital[] hospitals, Economic E)
		{
			long Sum = 0;
			for(int i  = 0; i < hospitals.Length; i++)
			{
				Sum += (hospitals[i].CorruptionLevel * E.HospitalBudget()) / (100 * hospitals.Length);
			}
			Sum += E.EducationBudget();

			return Convert.ToInt32(Sum / CoefOfEffective);
		}
	}
}