using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EpidemProc
{
	class GeneralOperations
	{
		public static bool Success(int probability)
		{
			Random rand = new Random();
			return probability > rand.Next(100);
		}
		public static bool Success(float probability)
		{
			Random rand = new Random();
			return probability > rand.Next(100);
		}
	}
}