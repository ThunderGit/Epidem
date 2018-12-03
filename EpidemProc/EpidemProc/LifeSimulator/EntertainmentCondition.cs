using EpidemProc.Models;
using EpidemProc.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EpidemProc.LifeSimulator
{
    class EntertainmentCondition
    {
        private static bool TimerCheck(int Hour, int StartFine, int EndFine)
        {
            return (Hour >= StartFine && Hour <= EndFine);
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
                             (HardWorker && TimerCheck(Hour, 21, 21))
                             ||
                             (!HardWorker && TimerCheck(Hour, 21, 21))
                        ))
                        ||
                        //Заводчанин
                        (Equals(Proffession, Profession.FactoryWorker) &&
                        (
                             (HardWorker && TimerCheck(Hour, 21, 21))
                             ||
                             (!HardWorker && TimerCheck(Hour, 19, 19))
                        ))
                        ||
                        //Медик
                        (Equals(Proffession, Profession.Medicine) &&
                        (
                             (HardWorker && TimerCheck(Hour, 19, 19))
                             ||
                             (!HardWorker && TimerCheck(Hour, 19, 19))
                        ))
                        ||
                        //Силовик
                        ((Equals(Proffession, Profession.Police) || Equals(Proffession, Profession.Millitary)) &&
                        (
                             (HardWorker && TimerCheck(Hour, 19, 19))
                             ||
                             (!HardWorker && TimerCheck(Hour, 19, 19))
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
                             (HardWorker && TimerCheck(Hour, 13, 16))
                             ||
                             (!HardWorker && TimerCheck(Hour, 13, 16))
                        ))
                        ||
                        //Заводчанин
                        (Equals(Proffession, Profession.FactoryWorker) &&
                        (
                             (HardWorker && TimerCheck(Hour, 13, 16))
                             ||
                             (!HardWorker && TimerCheck(Hour, 13, 16))
                        ))
                        ||
                        //Студент
                        (Equals(Proffession, Profession.Student) &&
                        (
                             (HardWorker && TimerCheck(Hour, 13, 14))
                             ||
                             (!HardWorker && TimerCheck(Hour, 13, 19))
                        ))
                        ||
                        //Медик
                        (Equals(Proffession, Profession.Medicine) &&
                        (
                             (HardWorker && TimerCheck(Hour, 13, 16))
                             ||
                             (!HardWorker && TimerCheck(Hour, 13, 16))
                        ))
                        ||
                        //Силовик
                        ((Equals(Proffession, Profession.Police) || Equals(Proffession, Profession.Millitary)) &&
                        (
                             (HardWorker && TimerCheck(Hour, 13, 16))
                             ||
                             (!HardWorker && TimerCheck(Hour, 13, 16))
                        ))
                    );
        }
        public static bool AtEntertainmentCondition(int Day, int Hour, int Proffession, bool HardWorker)
        {
            return CasualCondition(Day, Hour, Proffession, HardWorker) ||
                   WeekendCondition(Day, Hour, Proffession, HardWorker);
        }
    }
}