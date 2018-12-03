using EpidemProc.Models;
using EpidemProc.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EpidemProc.LifeSimulator
{
    class WorkCondition
    {
        private static bool TimerCheck(int Hour, int StartWorking, int EndWorking)
        {
            return (Hour >= StartWorking && Hour <= EndWorking);
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
                        //Заводчанин
                        (Equals(Proffession, Profession.FactoryWorker) &&
                        (
                             (HardWorker && TimerCheck(Hour, 9, 20))
                             ||
                             (!HardWorker && TimerCheck(Hour, 9, 18))
                        ))
                        ||
                        //Студент
                        (Equals(Proffession, Profession.Student) &&
                        (
                             (HardWorker && TimerCheck(Hour, 9, 16))
                             ||
                             (!HardWorker && TimerCheck(Hour, 9, 16))
                        ))
                        ||
                        //Медик
                        (Equals(Proffession, Profession.Medicine) &&
                        (
                             (HardWorker && TimerCheck(Hour, 9, 18))
                             ||
                             (!HardWorker && TimerCheck(Hour, 9, 18))
                        ))
                        ||
                        //Силовик
                        ((Equals(Proffession, Profession.Police) || Equals(Proffession, Profession.Millitary)) &&
                        (
                             (HardWorker && TimerCheck(Hour, 9, 18))
                             ||
                             (!HardWorker && TimerCheck(Hour, 9, 18))
                        ))
                        ||
                        //Продавец
                        (Equals(Proffession, Profession.Customer) &&
                        (
                             (HardWorker && TimerCheck(Hour, 14, 22))
                             ||
                             (!HardWorker && TimerCheck(Hour, 14, 22))
                        ))
                    );
        }
        private static bool WeekendCondition(int Day, int Hour, int Proffession, bool HardWorker)
        {
            return (Equals(Day, Days.Saturday) ||
                    Equals(Day, Days.Sunday))
                    &&
                    (
                        //Продавец
                        (Equals(Proffession, Profession.Customer) &&
                        (
                             (HardWorker && TimerCheck(Hour, 14, 22))
                             ||
                             (!HardWorker && TimerCheck(Hour, 14, 22))
                        ))
                    );
        }
        public static bool AtWorkCondition(int Day, int Hour, int Proffession, bool HardWorker)
        {
            return CasualCondition(Day, Hour, Proffession, HardWorker) ||
                   WeekendCondition(Day, Hour, Proffession, HardWorker);
        }
    }
}