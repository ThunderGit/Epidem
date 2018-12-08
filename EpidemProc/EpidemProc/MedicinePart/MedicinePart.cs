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



namespace EpidemProc.MedicinePart
{
	class MedicinePart
	{
//если здоров или ок, то не обращается. Если слабая болезнь но трудоголик то не обращается
		private static bool InviteCondition(Citizen patient)
		{
			if (Equals(patient.HealthStatus, HealthStatus.Critical)
				||
				Equals(patient.HealthStatus, HealthStatus.SeriousCold)
				||
				(Equals(patient.HealthStatus, HealthStatus.MildСold) && !patient.HardWorker))
			{
				return GeneralOperations.Success(patient.TrustTheDoctor);
			}
			else return false;
		}

		public static void Invites(ref Citizen [] patients, ref Hospital [] hospitals, Home [] home)
		{
			for(int i = 0; i < patients.Length; i++)
			{
				if (InviteCondition(patients[i]) && patients[i].WasSick == true)
				{
					
				}
			}
		}
	}
}