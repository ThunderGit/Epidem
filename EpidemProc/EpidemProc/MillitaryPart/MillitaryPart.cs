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

namespace EpidemProc.MilPart
{
	class MillitaryPart
	{

		private static void Barracks(Millitary millitary, Troop troop, ref Citizen[] citizens)
		{
			for(int i = 0; i < citizens.Length; i++)
			{
				if(citizens[i].Id == troop.CitizenId)
				{
					citizens[i].X = millitary.X;
					citizens[i].Y = millitary.Y;
					break;
				}
			}
		}

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


		private static void PoliceSupport(Police police, Troop troop, ref Citizen[] citizens)
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

		public static void MillitaryAction(Millitary[] millitaries, Troop[] troops,ref Citizen[] citizens, Hospital[] hospitals, Police[] polices, int status)
		{
			if(Equals(status, MillitaryStatus.HighAttention) || Equals(status, MillitaryStatus.StateOfEmergency))
			{
				for(int i = 0; i < troops.Length; i++)
				{
					for(int j = 0; j < millitaries.Length; j++)
					{
						if (troops[i].MilitaryId == millitaries[j].Id)
						{
							Barracks(millitaries[j], troops[i], ref citizens);
							break;
						}
					}
				}
			}
			else
			{
				if (Equals(status, MillitaryStatus.StateOfMillitary))
				{
					int hospitalIterator = 0;
					int policeIterator = 0;

					int soldercounter = 0;

					for (int i = 0; i < troops.Length; i++)
					{
						if(hospitalIterator < hospitals.Length)
						{
							if(soldercounter == 20)
							{
								soldercounter = 0;
								hospitalIterator++;
							}
							HospitalSupport(hospitals[hospitalIterator], troops[i], ref citizens);
							soldercounter++;
						}
						else if (policeIterator < polices.Length)
						{
							if (soldercounter == 30)
							{
								soldercounter = 0;
								policeIterator++;
							}
							PoliceSupport(polices[policeIterator], troops[i], ref citizens);
							soldercounter++;
						}
						else for (int j = 0; j < millitaries.Length; j++)
						{
							if (troops[i].MilitaryId == millitaries[j].Id)
							{
								Barracks(millitaries[j], troops[i], ref citizens);
								break;
							}
						}
					}
				}
			}
		}
	}
}