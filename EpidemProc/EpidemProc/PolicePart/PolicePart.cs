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

namespace EpidemProc.PolPart
{
	class PolicePart
	{

		private static void HospitalSupport(Hospital hospital, Troop troop, ref Citizen[] citizens)
		{
			for (int i = 0; i < citizens.Length; i++)
			{
				if (citizens[i].Id == troop.CitizenId)
				{
					citizens[i].X = hospital.X;
					citizens[i].Y = hospital.Y;
					break;
				}
			}
		}


		private static void Police(Police police, Troop troop, ref Citizen[] citizens)
		{
			for (int i = 0; i < citizens.Length; i++)
			{
				if (citizens[i].Id == troop.CitizenId)
				{
					citizens[i].X = police.X;
					citizens[i].Y = police.Y;
					break;
				}
			}
		}

		public static void PoliceAction(Troop[] troops,ref Citizen[] citizens, Hospital[] hospitals, Police[] polices, int status)
		{
			if(Equals(status, MillitaryStatus.StateOfMillitary))
			{
				for(int i = 0; i < troops.Length; i++)
				{
					for(int j = 0; j < polices.Length; j++)
					{
						if (troops[i].MilitaryId == polices[j].Id)
						{
							Police(polices[j], troops[i], ref citizens);
							break;
						}
					}
				}
			}
			else
			{
				if (Equals(status, MillitaryStatus.StateOfEmergency))
				{
					int hospitalIterator = 0;

					int policemancounter = 0;

					for (int i = 0; i < troops.Length; i++)
					{
						if(hospitalIterator < hospitals.Length)
						{
							if(policemancounter == 5)
							{
								policemancounter = 0;
								hospitalIterator++;
							}
							HospitalSupport(hospitals[hospitalIterator], troops[i], ref citizens);
							policemancounter++;
						}
						else for (int j = 0; j < polices.Length; j++)
						{
							if (troops[i].MilitaryId == polices[j].Id)
							{
								Police(polices[j], troops[i], ref citizens);
								break;
							}
						}
					}
				}
			}
		}
	}
}