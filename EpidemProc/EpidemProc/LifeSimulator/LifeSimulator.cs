using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EpidemProc.Models;
using EpidemProc.Enum;


//пока что жизнь идет по циклу одна итерация 1 час.
//жизнь обычных граждан регламентирована методом Lifemove.



namespace EpidemProc.LifeSimulator
{
    class Life
    {
        private static void AtHome(ref Citizen citizen, Home[] _Homes)
        {
            for (int i = 0; i < _Homes.Length; i++)
            {
                if (citizen.HomeId == _Homes[i].Id)
                {
                    citizen.X = _Homes[i].X;
                    citizen.Y = _Homes[i].Y;
                    break;
                }
            }
        }
        private static void AtWorkplace(ref Citizen citizen, Facture[] _Factures)
        {
            for (int i = 0; i < _Factures.Length; i++)
            {
                if (citizen.HomeId == _Factures[i].Id)
                {
                    citizen.X = _Factures[i].X;
                    citizen.Y = _Factures[i].Y;
                    break;
                }
            }
        }
        private static void InMagazine(ref Citizen citizen, Facture[] _Shops)
        {
            Random rand = new Random();
            int k = rand.Next(_Shops.Length);
            citizen.X = _Shops[k].X;
            citizen.Y = _Shops[k].Y;
        }
        private static void GoAway(ref Citizen citizen)
        {
            citizen.X = -1;
            citizen.Y = -1;
        }

        public static void Lifemove(Citizen[] _Citizens, Facture[] _Factures, Home[] _Homes, Facture[] _Shops, int Day, int Hour, int status)
        {
			for (int i = 0; i < _Citizens.Length; i++)
			{
				if (!_Citizens[i].Hospitalized)
				{

					if (HomeCondition.AtHomeCondition(Day, Hour, _Citizens[i].ProfessionId, _Citizens[i].HardWorker) || _Citizens[i].SickLeave || Equals(status, MillitaryStatus.StateOfMillitary))
					{
						AtHome(ref _Citizens[i], _Homes);
					}
					else if (WorkCondition.AtWorkCondition(Day, Hour, _Citizens[i].ProfessionId, _Citizens[i].HardWorker))
					{
						AtWorkplace(ref _Citizens[i], _Factures);
					}
					else if (EntertainmentCondition.AtEntertainmentCondition(Day, Hour, _Citizens[i].ProfessionId, _Citizens[i].HardWorker))
					{
						InMagazine(ref _Citizens[i], _Shops);
					}
					else if (GoAwayCondition.AwayCondition(Day, Hour, _Citizens[i].ProfessionId, _Citizens[i].HardWorker) || !Equals(status, MillitaryStatus.StateOfEmergency))
					{
						GoAway(ref _Citizens[i]);
					}
				}
			}
        }
    }
}
