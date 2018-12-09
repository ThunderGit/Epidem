using System;
using EpidemProc.Region;
using EpidemProc.Enum;

namespace EpidemProc.VirusPart
{
	class InfectFactors
	{
		public static int StatusFactor(int status)
		{
			if (Equals(status, MillitaryStatus.Calm)) return 100;
			else if (Equals(status, MillitaryStatus.HighAttention)) return 80;
			else if (Equals(status, MillitaryStatus.StateOfEmergency)) return 100;
			else return 110;
		}
		public static int TemperatureFactor(Weather weather, int coefMulct, int minT, int maxT)
		{
			if (weather.t > minT && weather.t > maxT)
				return 100;
			else 
				if (weather.t < minT)
					return 100 - coefMulct * Math.Abs(weather.t - minT);
				else
					return 100 - coefMulct * Math.Abs(weather.t - maxT);
		}
		public static int WetFactor(Weather weather, int wetProtect)
		{
			return 100 - Math.Abs(wetProtect - weather.wet);
		}
		public static int ImmunityFactor(int immunity)
		{
			return 100 - immunity;
		}
	}
}