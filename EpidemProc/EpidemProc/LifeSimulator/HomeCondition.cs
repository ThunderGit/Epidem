using EpidemProc.Models;
using EpidemProc.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EpidemProc.LifeSimulator
{
    class HomeCondition
    {
        private static bool TimerCheck(int Hour, int StartMorning, int EndMorning, int StartEvening, int EndEvening)
        {
            return (Hour >= StartMorning && Hour <= EndMorning) || (Hour >= StartEvening && Hour <= EndEvening);
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
                             (HardWorker && TimerCheck(Hour, 0, 8, 22, 24))
                             ||
                             (!HardWorker && TimerCheck(Hour, 0, 10, 22, 24))
                        ))
                        ||
                        //Заводчанин
                        (Equals(Proffession, Profession.FactoryWorker) &&
                        (
                             (HardWorker && TimerCheck(Hour, 0, 8, 22, 24))
                             ||
                             (!HardWorker && TimerCheck(Hour, 0, 8, 20, 24))
                        ))
                        ||
                        //Студент
                        (Equals(Proffession, Profession.Student) &&
                        (
                             (HardWorker && TimerCheck(Hour, 0, 8, 17, 24))
                             ||
                             (!HardWorker && TimerCheck(Hour, 0, 8, 17, 24))
                        ))
                        ||
                        //Медик
                        (Equals(Proffession, Profession.Medicine) &&
                        (
                             (HardWorker && TimerCheck(Hour, 0, 8, 20, 24))
                             ||
                             (!HardWorker && TimerCheck(Hour, 0, 8, 20, 24))
                        ))
                        ||
                        //Силовик
                        ((Equals(Proffession, Profession.Police) || Equals(Proffession, Profession.Millitary)) &&
                        (
                             (HardWorker && TimerCheck(Hour, 0, 8, 20, 24))
                             ||
                             (!HardWorker && TimerCheck(Hour, 0, 8, 20, 24))
                        ))
                        ||
                        //Продавец
                        (Equals(Proffession, Profession.Customer) &&
                        (
                             (HardWorker && TimerCheck(Hour, 0, 13, 22, 24))
                             ||
                             (!HardWorker && TimerCheck(Hour, 0, 13, 22, 24))
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
                             (HardWorker && TimerCheck(Hour, 0, 8, 17, 24))
                             ||
                             (!HardWorker && TimerCheck(Hour, 0, 12, 17, 24))
                        ))
                        ||
                        //Заводчанин
                        (Equals(Proffession, Profession.FactoryWorker) &&
                        (
                             (HardWorker && TimerCheck(Hour, 0, 12, 17, 24))
                             ||
                             (!HardWorker && TimerCheck(Hour, 0, 12, 17, 24))
                        ))
                        ||
                        //Студент
                        (Equals(Proffession, Profession.Student) &&
                        (
                             (HardWorker && TimerCheck(Hour, 0, 12, 15, 24))
                             ||
                             (!HardWorker && TimerCheck(Hour, 0, 12, 20, 24))
                        ))
                        ||
                        //Медик
                        (Equals(Proffession, Profession.Medicine) &&
                        (
                             (HardWorker && TimerCheck(Hour, 0, 12, 17, 24))
                             ||
                             (!HardWorker && TimerCheck(Hour, 0, 12, 17, 24))
                        ))
                        ||
                        //Силовик
                        ((Equals(Proffession, Profession.Police) || Equals(Proffession, Profession.Millitary)) &&
                        (
                             (HardWorker && TimerCheck(Hour, 0, 12, 17, 24))
                             ||
                             (!HardWorker && TimerCheck(Hour, 0, 12, 17, 24))
                        ))
                        ||
                        //Продавец
                        (Equals(Proffession, Profession.Customer) &&
                        (
                             (HardWorker && TimerCheck(Hour, 0, 13, 22, 24))
                             ||
                             (!HardWorker && TimerCheck(Hour, 0, 13, 22, 24))
                        ))
                    );
        }
        public static bool AtHomeCondition(int Day, int Hour, int Proffession, bool HardWorker)
        {
            return CasualCondition(Day, Hour, Proffession, HardWorker) ||
                   WeekendCondition(Day, Hour, Proffession, HardWorker);
        }
    }
}