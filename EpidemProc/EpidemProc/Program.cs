using System;
using EpidemProc.LifeSimulator;
using EpidemProc.VirusPart;
using EpidemProc.Region;
using EpidemProc.Models;
using EpidemProc.Enum;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EpidemProc.MedPart;
using EpidemProc.Scientist;
using EpidemProc.MilPart;
using EpidemProc.PolPart;

namespace EpidemProc
{
    class Program
    {
        static Citizen[] _Citizens;
        static Policeman[] _Policeman;
        static Doctor[] _Doctor;
        static Troop[] _Troop ;
        static Police[] _Police;
        static Hospital[] _Hospital;
        static Millitary[] _Millitary;
        static Facture[] _Facture;
        static Home[] _Home;
        static Facture[] _Shop;


        static void PrepareData()
        {
            List<Facture> tmp = new List<Facture>();
            for (int i = 0; i< _Facture.Length; i++)
            {
                if(Equals(_Facture[i].Type, FactureType.Shop))
                {
                    tmp.Add(_Facture[i]);
                }
            }
            _Shop = tmp.ToArray();
        }

        static void LoadData()
        {
            Loader loader = new Loader(@"DESKTOP-SH16UUG", "PANDEMIC_INC");
            loader.Load(ref _Citizens, ref _Policeman, ref _Doctor, ref _Troop, ref _Police,
                ref _Hospital, ref _Millitary, ref _Facture, ref _Home);
            //All = loader.Load<Citizen>();
        }

        static void Main(string[] args)
        {
            //подгрузка
            LoadData();
            PrepareData();
			//счетчик дней
			int day = 6;
			int hour = 0;
			int totalDay = 0;
			int currentDay = 335;
			long iterator = 0;
			int status = 0;
			int researchProgress = 0;
			int countOfDeath = 0;
			Virus virus = new Virus();
			Weather weather = new Weather();
			MedicinePart med = new MedicinePart();
			Economic Econimic = new Economic(25, 20, 20, 20, 15);
			while (_Citizens.Length != 0 || researchProgress != 100)
			{
				//перенмещение жителей
				Life.Lifemove(_Citizens, _Facture, _Home, _Shop, day, hour, status);
				PolicePart.PoliceAction(_Troop, ref _Citizens, _Hospital, _Police, status);
				MillitaryPart.MillitaryAction(_Millitary, _Troop, ref _Citizens, _Hospital, _Police, status);
				//заражение(если возможно)
				virus.Infect(ref _Citizens, weather, status);
				//в начале каждого нового дня поражение зараженных
				if (hour == 0)
				{ 
					virus.Damaged(ref _Citizens, weather, status);
					virus.Death(ref _Citizens, ref _Doctor, ref _Policeman, ref _Troop, ref countOfDeath);
				}
				//мутация раз в неделю
				if (Equals(day, Days.Monday))
				{
					int countOfInfected = 0;
					for (int i = 0; i < _Citizens.Length; i++)
						if (_Citizens[i].WasSick)
							countOfInfected++;
					virus.Mutate(_Citizens.Length, countOfInfected);
					if(Equals(status, MillitaryStatus.StateOfEmergency) || Equals(status, MillitaryStatus.StateOfMillitary))
					{
						researchProgress += ScientistPart.Research(_Hospital, Econimic, virus);
					}
				}
				//оращение к врачу
				if (hour == 9)
				{
					med.Invites(ref _Citizens, ref _Hospital, _Home, _Doctor);
					med.Hospitalizations(ref _Citizens, ref _Hospital, _Home);
					med.LeavesHospital(ref _Citizens, ref _Hospital, _Home);
				}
				//просчет статистики каждый 30 день
				if(totalDay % 30 == 0)
				{
					status = Medstat.Statistic(_Hospital, _Citizens.Length, countOfDeath);
				}
				//конец цикла перепросчет дневной статистики и изменение погоды
				hour++;
				iterator++;
				if (hour == 24)
				{
					hour = 0;
					day++;
					totalDay++;
					currentDay++;
					weather.ChangeWeather(currentDay);
					if (day == 7) { day = 0; }
					if (currentDay == 366) currentDay = 1;
				}	
			}
            Console.ReadKey();
        }
    }
}