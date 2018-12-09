﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EpidemProc.VirusPart;
using EpidemProc.Region;
using EpidemProc.Models;
using EpidemProc.Enum;
using EpidemProc;


namespace EpidemProc.Region
{
	class Medstat
	{
		public static void Statistic(Hospital[] hospitals, int status, int population, int countOfDeath)
		{
			long sum = 0;
			for(int i = 0; i < hospitals.Length;i++)
				sum += hospitals[i].CountOfVisiters;
			float percentOfInfect = sum * 100 / population;
			float percentOfDead = countOfDeath * 100 / population;
			if (percentOfInfect <= 7 || percentOfDead <= 2) status = 0;
			else if (percentOfInfect > 7 && percentOfInfect <= 35 || percentOfDead <= 20) status = 1;
			else if (percentOfInfect > 35 && percentOfInfect <= 80 || percentOfDead <= 45) status = 2;
			else status = 3;
		}
	}
}