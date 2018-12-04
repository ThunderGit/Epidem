using EpidemProc.Models;
using EpidemProc.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EpidemProc.LifeSimulator
{
    class GoAwayCondition
    {
        private static bool TimerCheck(int Hour, int StartGoAway, int EndGoAway)
        {
            return (Hour >= StartGoAway && Hour <= EndGoAway);
        }

        private static bool CasualCondition(int Day, int Hour, int Proffession, bool HardWorker)
        {
            return (Equals(Day, Days.Monday) ||
                    Equals(Day, Days.Tuesday) ||
                    Equals(Day, Days.Wednesday) ||
                    Equals(Day, Days.Thursday) ||
                    Equals(Day, Days.Friday))
                    &&
                    (
                        //Безработный
                        (Equals(Proffession, Profession.NoWork) && 
                        (
                             (HardWorker && TimerCheck(Hour, 9, 20))
                             ||
                             (!HardWorker && TimerCheck(Hour, 11, 20))
                        ))
                    );
        }
        private static bool WeekendCondition(int Day, int Hour, int Proffession, bool HardWorker)
        {
            return (Equals(Day, Days.Saturday) ||
                    Equals(Day, Days.Sunday))
                    &&
                    (
                        //Безработный
                        (Equals(Proffession, Profession.NoWork) &&
                        (
                             (HardWorker && TimerCheck(Hour, 9, 12))
                        ))
                    );
        }
        public static bool AwayCondition(int Day, int Hour, int Proffession, bool HardWorker)
        {
            return CasualCondition(Day, Hour, Proffession, HardWorker) ||
                   WeekendCondition(Day, Hour, Proffession, HardWorker);
        }
    }
}