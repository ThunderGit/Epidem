using System;

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