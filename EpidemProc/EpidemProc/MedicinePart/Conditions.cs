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
	class Conditions
	{
		public static bool InviteCondition(Citizen patient)
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

		public static bool HospitalizeCondition(Citizen patient)
		{
			if (Equals(patient.HealthStatus, HealthStatus.Critical)) return true;
			else return false;
		}
	}
}