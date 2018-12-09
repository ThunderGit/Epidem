using System;
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
		private int EducationPartOfBudget;
		private int MedicinePartOfBudget;
		private int PolicePartOfBudget;
		private int MillitaryPartOfBudget;
		private int CorruptionLevel;
		private long Sum;

		public Economic(int _EducationPartOfBudget, int _MedicinePartOfBudget, int _PolicePartOfBudget, int _MillitaryPartOfBudget, int _CorruptionLevel)
		{
			EducationPartOfBudget = _EducationPartOfBudget;
			MedicinePartOfBudget = _MedicinePartOfBudget;
			PolicePartOfBudget = _PolicePartOfBudget;
			MillitaryPartOfBudget = _MillitaryPartOfBudget;
			CorruptionLevel = _CorruptionLevel;
			Sum = 0;
		}

		public float SickStatus(bool Leave, bool Hospitalized)
		{
			if (Hospitalized) return 0;
			else if (Leave) return 0.5f;
			else return 1;
		}

		public long Budget(Citizen [] citizens)
		{
			Sum = 0;
			for (int i = 0; i < citizens.Length; i++)
				Sum += Convert.ToInt32(citizens[i].Salary * SickStatus(citizens[i].SickLeave, citizens[i].Hospitalized));
			return Sum;
		}

		public long HospitalBudget()
		{
			return Sum * MedicinePartOfBudget ; 
		}
		public long PoliceBudget()
		{
			return Sum * PolicePartOfBudget;
		}
		public long MillitaryBudget()
		{
			return Sum * MillitaryPartOfBudget;
		}
		public long EducationBudget()
		{
			return Sum * EducationPartOfBudget;
		}
	}
}