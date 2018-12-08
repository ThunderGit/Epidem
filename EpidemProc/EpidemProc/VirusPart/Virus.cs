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

		//факторы поражения систем
		public int skeletonDamaged;
		public int muscleDamaged;
		public int respiratoryDamaged;
		public int circulatoryDamaged;
		public int diureticDamaged;
		public int digestiveDamaged;
		public int nervousDamaged;
		public int reproductiveDamaged;
		public int sensoryDamaged;
		public int lyphaticDamaged;
		public int immunityDamaged;

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
			skeletonDamaged = 0;
			muscleDamaged = 1;
			respiratoryDamaged = 3;
			circulatoryDamaged = 0;
			diureticDamaged = 1;
			digestiveDamaged = 0;
			nervousDamaged = 2;
			reproductiveDamaged = 0;
			sensoryDamaged = 1;
			lyphaticDamaged = 2;
			immunityDamaged = 3;
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

		//заражение
		private void TryInfect(Weather weather, Citizen Infected, ref Citizen Healthy)
		{
			//формулы расчета нахождения здоровых граждан в одном квадрате с зараженным
			if (Math.Abs((Healthy.X / 20 - Infected.X / 20)) <= DangerInfectRadius &&
				Math.Abs((Healthy.Y / 20 - Infected.Y / 20)) <= DangerInfectRadius &&
				Healthy != Infected)
			{
				//формула заражения
				if (InfectCondition(weather, Healthy))
				{
					Healthy.WasSick = true;
				}
			}
		}
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
				for (int i = 0; i < _Infected.Length; i++)
					for (int j = 0; j < _Healthy.Length; j++)
						TryInfect(weather, _Infected[i], ref _Healthy[j]);
			}
		}
		//ухудшение здоровья
		private int SumOfTotalDamage()
		{
			return	skeletonDamaged		+ muscleDamaged			+ respiratoryDamaged +
					circulatoryDamaged	+ diureticDamaged		+ digestiveDamaged +
					nervousDamaged		+ reproductiveDamaged	+ sensoryDamaged +
					lyphaticDamaged;
		}
		public int ChangeHealthStatus(int healthLevel)
		{
			if (healthLevel >= 90) { return 0; }
			else
			{
				if (healthLevel >= 80) { return 1; }
				else
				{
					if (healthLevel >= 60) { return 2; }
					else
					{
						if (healthLevel >= 40) { return 3; }
						else return 4;
					}
				}
			}
		}
		private void TryDamaged(Weather weather, ref Citizen Infected)
		{
			Infected.Immunity -= immunityDamaged/2 + 1;
			Infected.Health -= (100 - Infected.Immunity) * SumOfTotalDamage() / 2;
			Infected.HealthStatus = ChangeHealthStatus(Infected.Health);
		}
		public void Damaged(ref Citizen[] _Citizens, Weather weather)
		{
			if (weather.t >= MaxComfortTemperature && weather.t <= MinComfortTemperature) return;
			else
			{
				List<Citizen> tmpI = new List<Citizen>();
				for (int i = 0; i < _Citizens.Length; i++)
					if (_Citizens[i].WasSick == true)
						tmpI.Add(_Citizens[i]);
				Citizen[] _Infected = tmpI.ToArray();
				for (int i = 0; i < _Infected.Length; i++)
					TryDamaged(weather, ref _Infected[i]);
			}
		}
	}
}