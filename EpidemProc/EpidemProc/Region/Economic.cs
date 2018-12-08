﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EpidemProc.VirusPart;
using EpidemProc.Region;
using EpidemProc.Models;
using EpidemProc.Enum;

namespace EpidemProc.Region
{
	class Economic
	{
		private static int EducationPartOfBudget;
		private static int MedicinePartOfBudget;
		private static int PolicePartOfBudget;
		private static int MillitaryPartOfBudget;
		private static int CorruptionLevel;
		private static long Sum;

		Economic(int _EducationPartOfBudget, int _MedicinePartOfBudget, int _PolicePartOfBudget, int _MillitaryPartOfBudget, int _CorruptionLevel)
		{
			EducationPartOfBudget = _EducationPartOfBudget;
			MedicinePartOfBudget = _MedicinePartOfBudget;
			PolicePartOfBudget = _PolicePartOfBudget;
			MillitaryPartOfBudget = _MillitaryPartOfBudget;
			CorruptionLevel = _CorruptionLevel;
			Sum = 0;
		}
		public static long Budget(Citizen [] citizens)
		{
			Sum = 0;
			for (int i = 0; i < citizens.Length; i++)
				Sum += citizens[i].Salary;
			return Sum;
		}

		public static long HospitalBudget(Hospital [] hospitals)
		{
			return Sum * CorruptionLevel * MedicinePartOfBudget / (100 * 100 * hospitals.Length); 
		}
		public static long PoliceBudget(Police[] polices)
		{
			return Sum * CorruptionLevel * PolicePartOfBudget / (100 * 100 * polices.Length);
		}
		public static long MillitaryBudget(Millitary[] millitaries)
		{
			return Sum * CorruptionLevel * MillitaryPartOfBudget / (100 * 100 * millitaries.Length);
		}

	}
}