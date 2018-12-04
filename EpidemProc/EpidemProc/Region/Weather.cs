using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EpidemProc.Region
{
    class Weather
    {
        public int t;
        public int wet;
		public bool isRain;

		public Weather()
		{
			t = -3;
			wet = 60;
			isRain = false;
		}
		public void ChangeWeather(int daypos)
		{
			Random rand = new Random();
			int rainprobably = rand.Next(100);
			if(rainprobably < 25)
			{
				isRain = true;
				if (wet + 30 <= 100) wet += 30;
				else wet = 100;
				t--;
			}
			else
			{
				isRain = false;
				if (wet - 1 >=10) wet --;
				else wet = 10;
			}
			ChangeTemperature(daypos);
		}
		private void ChangeTemperature(int daypos)
		{
			Random rand = new Random();
			if (daypos > 20 && daypos < 274) 
			{
				if (t < 43) t += rand.Next(2);
				else t -= 3;
			}
			else
			{
				if (t > -25) t -= rand.Next(4);
				else t += 2;
			}
		}
    }
}