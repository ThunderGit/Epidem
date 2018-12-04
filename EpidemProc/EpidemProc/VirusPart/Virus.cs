using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EpidemProc.Models;
using EpidemProc.Region;

namespace EpidemProc.VirusPart
{
    class Virus
    {
        //радиус заражения
        public int DangerInfectRadius;
        //сила заражения
        public int Power;
        //сложность лечения
        public int Difficult;
		//минимальная для заражения темспература
		public int MinInfectTemperature;
		//максимальная для заражения темспература
		public int MaxInfectTemperature;
		//минимальная для выживания темспература
		public int MinComfortTemperature;
		//максимальная для выживания темспература
		public int MaxComfortTemperature;
		//идеальная для заражения влажность
		public int WetProtect;
		//коефициент критичности некомфортных условий, влияющих на заражение
		public int CoefDifficultInfectDuringUncomfort;

		public Virus()
        {
            DangerInfectRadius = 1;
            Power = 1;
            Difficult = 1;
			MinInfectTemperature = -5;
			MaxInfectTemperature = 25;
			MinComfortTemperature = -15;
			MaxComfortTemperature = 35;
			WetProtect = 60;
			CoefDifficultInfectDuringUncomfort = 7;
		}


		private bool InfectCondition(Weather weather, Citizen PotentialPatient)
		{
			Random rand = new Random();
			int wetFactor = 100 - Math.Abs(WetProtect - weather.wet);
			int temperatureFactor;
			if (weather.t > MinInfectTemperature && weather.t > MaxInfectTemperature)
				temperatureFactor = 100;
			else
				if (weather.t < MinInfectTemperature)
				temperatureFactor = 100 - 7 * Math.Abs(weather.t - MinInfectTemperature);
			else
				temperatureFactor = 100 - 7 * Math.Abs(weather.t - MaxInfectTemperature);

			int imunityFactor = 100 - PotentialPatient.Immunity;
			float probability = (3 *imunityFactor + wetFactor + temperatureFactor) / 5;
			if (probability > rand.Next(100))
				return true;
			else
				return false;
		}


		//метод заражения
		public void Infect(ref Citizen[] _Citizens, Weather weather)
		{
			//если температурные условие вне пределах приемлемых, то метод не работает
			if (weather.t >= MaxComfortTemperature && weather.t <= MinComfortTemperature) return;
			else
			{ 
				//разделение жителей на уже зараженных и здоровых
				List<Citizen> tmpI = new List<Citizen>();
				List<Citizen> tmpH = new List<Citizen>();
				for (int i = 0; i < _Citizens.Length; i++)
					if (_Citizens[i].WasSick == true)
						tmpI.Add(_Citizens[i]);
					else 
						tmpH.Add(_Citizens[i]);
				Citizen[] _Infected = tmpI.ToArray();
				Citizen[] _Healthy = tmpH.ToArray();

				//цикл возможности заражения здоровых людей каждым зараженным
				for (int i = 0; i < _Infected.Length; i++)
				{
					for (int j = 0; j < _Healthy.Length; j++)
					{
						//формулы расчета нахождения здоровых граждан в одном квадрате с зараженным
						if (Math.Abs((_Healthy[j].X / 20 - _Infected[i].X / 20)) <= DangerInfectRadius &&
							Math.Abs((_Healthy[j].Y / 20 - _Infected[i].Y / 20)) <= DangerInfectRadius &&
							_Healthy[j] != _Infected[i])
						{
							//формула заражения
							if (InfectCondition(weather, _Healthy[j]))
							{
								_Healthy[j].WasSick = true;
							}
						}
					}
				}
			}
		}   
	}
}