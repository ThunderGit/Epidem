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
		//минимальная для заражения температура
		public int MinInfectTemperature;
		//максимальная для заражения температура
		public int MaxInfectTemperature;
		//минимальная для выживания температура
		public int MinComfortTemperature;
		//максимальная для выживания температура
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

        public int ProbabilityOfPositiveMutation;

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
            ProbabilityOfPositiveMutation = 80;
	}


		private bool InfectCondition(Weather weather, Citizen PotentialPatient)
		{
			int wetFactor = 100 - Math.Abs(WetProtect - weather.wet);
			int temperatureFactor;
			if (weather.t > MinInfectTemperature && weather.t > MaxInfectTemperature)
				temperatureFactor = 100;
			else
				if (weather.t < MinInfectTemperature)
				temperatureFactor = 100 - CoefDifficultInfectDuringUncomfort * Math.Abs(weather.t - MinInfectTemperature);
			else
				temperatureFactor = 100 - CoefDifficultInfectDuringUncomfort * Math.Abs(weather.t - MaxInfectTemperature);

			int imunityFactor = 100 - PotentialPatient.Immunity;
			float probability = (3 *imunityFactor + wetFactor + temperatureFactor) / 5;
			if (GeneralOperations.Success(probability))
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
			Infected.Health -= (100 - Infected.Immunity)/100 * SumOfTotalDamage() / 2;
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
                {
                    TryDamaged(weather, ref _Infected[i]);
                    if (_Infected[i].Health <= 0)
                    {
                        List<Citizen> lst = new List<Citizen>(_Citizens);
                        lst.Remove(_Infected[i]);
                        _Citizens = lst.ToArray();
                    }
                }
			}
		}

        public void Mutate(int NumberOfCitizens, int NumberOfInfected)
        {
            Random rand = new Random();
            int mutateprobably = rand.Next(100);
            if (mutateprobably > (NumberOfInfected / NumberOfCitizens) * 100) return;

            int mutatepositive = rand.Next(100);
            bool IsMutationPositive = mutatepositive < this.ProbabilityOfPositiveMutation;

            int caseOfMutation = rand.Next(100);

            if (IsMutationPositive)
            {
                switch (caseOfMutation)
                {
                    case 1:
                    case 2:
                        if (this.Difficult < 10) this.Difficult++;
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        if (this.MinInfectTemperature > this.MinComfortTemperature) this.MinInfectTemperature--;
                        break;
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                        if (this.MaxInfectTemperature < this.MaxComfortTemperature) this.MaxInfectTemperature++;
                        break;
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                        if (this.MinComfortTemperature > -25) this.MinComfortTemperature--;
                        break;
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                    case 26:
                        if (this.MaxComfortTemperature < 43) this.MaxComfortTemperature++;
                        break;
                    case 27:
                        if (this.CoefDifficultInfectDuringUncomfort > 2) this.CoefDifficultInfectDuringUncomfort--;
                        break;
                    case 28:
                    case 29:
                        if (this.skeletonDamaged < 10) this.skeletonDamaged++;
                        break;
                    case 30:
                    case 31:
                    case 32:
                        if (this.muscleDamaged < 10) this.muscleDamaged++;
                        break;
                    case 33:
                    case 34:
                    case 35:
                    case 36:
                    case 37:
                        if (this.respiratoryDamaged < 10) this.respiratoryDamaged++;
                        break;
                    case 38:
                    case 39:
                        if (this.circulatoryDamaged < 10) this.circulatoryDamaged++;
                        break;
                    case 40:
                    case 41:
                    case 42:
                        if (this.diureticDamaged < 10) this.diureticDamaged++;
                        break;
                    case 43:
                    case 44:
                        if (this.digestiveDamaged < 10) this.digestiveDamaged++;
                        break;
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                        if (this.nervousDamaged < 10) this.nervousDamaged++;
                        break;
                    case 49:
                    case 50:
                        if (this.reproductiveDamaged < 10) this.reproductiveDamaged++;
                        break;
                    case 51:
                    case 52:
                    case 53:
                        if (this.sensoryDamaged < 10) this.sensoryDamaged++;
                        break;
                    case 54:
                    case 55:
                    case 56:
                    case 57:
                        if (this.lyphaticDamaged < 10) this.lyphaticDamaged++;
                        break;
                    case 58:
                    case 59:
                    case 60:
                    case 61:
                    case 62:
                        if (this.immunityDamaged < 10) this.immunityDamaged++;
                        break;
                }
            }
            else
            {
                switch (caseOfMutation)
                {
                    case 1:
                    case 2:
                        if (this.Difficult > 0) this.Difficult--;
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        if (this.MinInfectTemperature < this.MaxInfectTemperature) this.MinInfectTemperature++;
                        break;
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                        if (this.MaxInfectTemperature > this.MinInfectTemperature) this.MaxInfectTemperature--;
                        break;
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                        if (this.MinComfortTemperature < this.MinInfectTemperature) this.MinComfortTemperature++;
                        break;
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                    case 26:
                        if (this.MaxComfortTemperature > this.MaxInfectTemperature) this.MaxComfortTemperature--;
                        break;
                    case 27:
                        if (this.CoefDifficultInfectDuringUncomfort < 10) this.CoefDifficultInfectDuringUncomfort++;
                        break;
                    case 28:
                    case 29:
                        if (this.skeletonDamaged > 0) this.skeletonDamaged--;
                        break;
                    case 30:
                    case 31:
                    case 32:
                        if (this.muscleDamaged > 0) this.muscleDamaged--;
                        break;
                    case 33:
                    case 34:
                    case 35:
                    case 36:
                    case 37:
                        if (this.respiratoryDamaged > 0) this.respiratoryDamaged--;
                        break;
                    case 38:
                    case 39:
                        if (this.circulatoryDamaged > 0) this.circulatoryDamaged--;
                        break;
                    case 40:
                    case 41:
                    case 42:
                        if (this.diureticDamaged > 0) this.diureticDamaged--;
                        break;
                    case 43:
                    case 44:
                        if (this.digestiveDamaged > 0) this.digestiveDamaged--;
                        break;
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                        if (this.nervousDamaged > 0) this.nervousDamaged--;
                        break;
                    case 49:
                    case 50:
                        if (this.reproductiveDamaged > 0) this.reproductiveDamaged--;
                        break;
                    case 51:
                    case 52:
                    case 53:
                        if (this.sensoryDamaged > 0) this.sensoryDamaged--;
                        break;
                    case 54:
                    case 55:
                    case 56:
                    case 57:
                        if (this.lyphaticDamaged > 0) this.lyphaticDamaged--;
                        break;
                    case 58:
                    case 59:
                    case 60:
                    case 61:
                    case 62:
                        if (this.immunityDamaged > 0) this.immunityDamaged--;
                        break;
                }
            }
        }
    }
}