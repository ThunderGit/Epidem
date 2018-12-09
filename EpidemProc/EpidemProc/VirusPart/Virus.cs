using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EpidemProc.Models;
using EpidemProc.Region;
using EpidemProc.Enum;

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
		public int MinInfectT;
		//максимальная для заражения температура
		public int MaxInfectT;
		//минимальная для выживания температура
		public int MinComfortT;
		//максимальная для выживания температура
		public int MaxComfortT;
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
			MinInfectT = -5;
			MaxInfectT = 25;
			MinComfortT = -15;
			MaxComfortT = 35;
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


		//заражение
		private void TryInfect(Weather weather, Citizen Infected, ref Citizen Healthy, int status)
		{
			//формулы расчета нахождения здоровых граждан в одном квадрате с зараженным
			if (InfectCondition.PathCondition(Healthy, Infected, this))
			{
				if (InfectCondition.Condition(weather, Healthy, status, this))
				{
					Healthy.WasSick = true;
				}			
			}
		}
		public void Infect(ref Citizen[] _Citizens, Weather weather, int status)
		{
			//если температурные условие вне пределах приемлемых, то метод не работает
			if (weather.t >= MaxComfortT && weather.t <= MinComfortT) return;
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
						TryInfect(weather, _Infected[i], ref _Healthy[j], status);

                int count = 0;
                for (int i = 0; i < _Infected.Length;)
                {
                    for (int j = 0; j < _Healthy.Length;)
                    {
                        if (_Infected[i].Id < _Healthy[i].Id)
                        {
                            _Citizens[count] = _Infected[i];
                            i++;
                        }
                        else
                        {
                            _Citizens[count] = _Healthy[j];
                            j++;
                        }
                        count++;
                    }
                }
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
		private void TryDamaged(Weather weather, ref Citizen Infected, int status)
		{
			Infected.Immunity -= immunityDamaged/2 + 1;
			Infected.Health -= (100 - Infected.Immunity)/100 * SumOfTotalDamage() / 2;
			//влияние статуса повышенного внимания
			if(status == 1){ Infected.Immunity += 2; }
			//влияние госпитализации
			if (Infected.Hospitalized == true) { Infected.Health+=2; }
			Infected.HealthStatus = ChangeHealthStatus(Infected.Health);
		}
		public void Damaged(ref Citizen[] _Citizens, Weather weather, int status)
		{
			if (weather.t >= MaxComfortT && weather.t <= MinComfortT) return;
			else
			{
                for (int i = 0; i < _Citizens.Length; i++)
                {
                    if (_Citizens[i].WasSick == true)
                    {
                        TryDamaged(weather, ref _Citizens[i], status);
                        if (_Citizens[i].Health <= 0)
                        {
                            List<Citizen> lst = new List<Citizen>(_Citizens);
                            lst.Remove(_Citizens[i]);
                            _Citizens = lst.ToArray();
                        }
                    }
                }
			}
		}
		//мутация
        public void Mutate(int NumberOfCitizens, int NumberOfInfected)
        {
            if (GeneralOperations.Success((NumberOfInfected / NumberOfCitizens) * 100)) return;
			int coefOfMutate;
			if (GeneralOperations.Success(ProbabilityOfPositiveMutation)) coefOfMutate = 1;
			else coefOfMutate = -1;

			Random rand = new Random();
            int caseOfMutation = rand.Next(100);
			switch (caseOfMutation)
			{
				case int n when (n <= 2):
					if (MutateConditions.DifficultConditions(Difficult)) 
						Difficult += coefOfMutate;
					break;
				case int n when (n > 2 && n <= 8):
					if (MutateConditions.MinInfectTConditions(MaxInfectT, MaxInfectT, MinComfortT, MaxComfortT))
						MinInfectT += coefOfMutate;
					break;
				case int n when (n > 8 && n <= 14):
					if (MutateConditions.MaxInfectTConditions(MaxInfectT, MaxInfectT, MinComfortT, MaxComfortT))
						MaxInfectT += coefOfMutate;
					break;
				case int n when (n > 15 && n <= 20):
					if (MutateConditions.MinComfortTConditions(MaxInfectT, MaxInfectT, MinComfortT, MaxComfortT))
						MinComfortT += coefOfMutate;
					break;
				case int n when (n > 20 && n <= 26):
					if (MutateConditions.MaxComfortTConditions(MaxInfectT, MaxInfectT, MinComfortT, MaxComfortT))
						MaxComfortT += coefOfMutate;
					break;
				case 27:
					if (MutateConditions.CoefDifficultInfectConditions(CoefDifficultInfectDuringUncomfort))
						CoefDifficultInfectDuringUncomfort += coefOfMutate;
					break;
				case int n when (n > 27 && n <= 29):
					if (MutateConditions.SystemDamagedConditions(skeletonDamaged))
						skeletonDamaged += coefOfMutate;
					break;
				case int n when (n > 29 && n <= 32):
					if (MutateConditions.SystemDamagedConditions(muscleDamaged))
						muscleDamaged += coefOfMutate;
					break;
				case int n when (n > 32 && n <= 37):
					if (MutateConditions.SystemDamagedConditions(respiratoryDamaged))
						respiratoryDamaged += coefOfMutate;
					break;
				case int n when (n > 37 && n <= 39):
					if (MutateConditions.SystemDamagedConditions(circulatoryDamaged))
						circulatoryDamaged += coefOfMutate;
					break;
				case int n when (n > 39 && n <= 42):
					if (MutateConditions.SystemDamagedConditions(diureticDamaged))
						diureticDamaged += coefOfMutate;
					break;
				case int n when (n > 42 && n <= 44):
					if (MutateConditions.SystemDamagedConditions(digestiveDamaged))
						digestiveDamaged += coefOfMutate;
					break;
				case int n when (n > 44 && n <= 48):
					if (MutateConditions.SystemDamagedConditions(nervousDamaged))
						nervousDamaged += coefOfMutate;
					break;
				case int n when (n > 48 && n <= 50):
					if (MutateConditions.SystemDamagedConditions(reproductiveDamaged))
						reproductiveDamaged += coefOfMutate;
					break;
				case int n when (n > 50 && n <= 53):
					if (MutateConditions.SystemDamagedConditions(sensoryDamaged))
						sensoryDamaged += coefOfMutate;
					break;
				case int n when (n > 53 && n <= 57):
					if (MutateConditions.SystemDamagedConditions(lyphaticDamaged))
						lyphaticDamaged += coefOfMutate;
					break;
				case int n when (n > 57 && n <= 62):
					if (MutateConditions.SystemDamagedConditions(immunityDamaged))
						immunityDamaged += coefOfMutate;
					break;
			}
        }
     }
}