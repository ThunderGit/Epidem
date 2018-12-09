using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EpidemProc.Models;
using EpidemProc.Region;
using EpidemProc.Enum;

namespace EpidemProc.VirusPart
{
	class MutateConditions
	{
		//условие для проверки своства сложности вируса
		public static bool DifficultConditions(int difficult)
		{
			return difficult < 10 && difficult > 0;
		}
		//условия для проверки температур
		public static bool MinInfectTConditions(int MinInfT, int MaxInfT, int MinComfT, int MaxComfT)
		{
			return MinInfT > MinComfT && MinInfT < MaxInfT;
		}
		public static bool MaxInfectTConditions(int MinInfT, int MaxInfT, int MinComfT, int MaxComfT)
		{
			return MaxInfT < MaxComfT && MaxInfT > MinInfT;
		}
		public static bool MinComfortTConditions(int MinInfT, int MaxInfT, int MinComfT, int MaxComfT)
		{
			return MinComfT > -25 && MinComfT < MinInfT;
		}
		public static bool MaxComfortTConditions(int MinInfT, int MaxInfT, int MinComfT, int MaxComfT)
		{
			return MinComfT < 43 && MinComfT > MaxInfT;
		}
		//условие для проверки свойства штрафа
		public static bool CoefDifficultInfectConditions(int coef)
		{
			return coef > 2 && coef < 10;
		}
		//условие для проверки свойств поражения систем органов
		public static bool SystemDamagedConditions(int systemName)
		{
			return systemName < 10 && systemName > 0;
		}
		

	}
}