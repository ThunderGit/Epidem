using System;
using EpidemProc.LifeSimulator;
using EpidemProc.VirusPart;
using EpidemProc.Region;
using EpidemProc.Models;
using EpidemProc.Enum;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

			Virus virus = new Virus();
			Weather weather = new Weather();
			while (totalDay != 365)
			{
				//перенмещение жителей
				Life.Lifemove(_Citizens, _Facture, _Home, _Shop, day, hour);
				//заражение(если возможно)
				virus.Infect(ref _Citizens, weather);
				//в начале каждого нового дня заражение
				if(hour == 0)
				{
					virus.Damaged(ref _Citizens, weather);
				}
				//Console.WriteLine(currentDay);
				Console.WriteLine(weather.t);
				//Console.WriteLine(weather.wet);
				//конец цикла перепросчет дневнойстатистики и изменение погоды
				hour++;
				if (hour == 24)
				{
					hour = 0;
					day++;
					totalDay++;
					currentDay++;
					weather.ChangeWeather(currentDay);
					if (day == 8) { day = 0; }
					if (currentDay == 366) currentDay = 1;
				}	
			}
            Console.ReadKey();
        }
    }
}