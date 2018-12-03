using System;
using EpidemProc.Models;
using EpidemProc.LifeSimulator;


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

        static void LoadData()
        {
            Loader loader = new Loader(@"DESKTOP-SH16UUG", "PANDEMIC_INC");
            loader.Load(ref _Citizens, ref _Policeman, ref _Doctor, ref _Troop, ref _Police,
                ref _Hospital, ref _Millitary, ref _Facture, ref _Home);
            //All = loader.Load<Citizen>();
        }

        static void Main(string[] args)
        {
            //нужно достать эти данные
            LoadData();
            Console.WriteLine(_Citizens.Length);
            Console.WriteLine(_Policeman.Length);
            Console.WriteLine(_Doctor.Length);
            Console.WriteLine(_Troop.Length);
            Console.WriteLine(_Police.Length);
            Console.WriteLine(_Hospital.Length);
            Console.WriteLine(_Millitary.Length);
            Console.WriteLine(_Facture.Length);
            Console.WriteLine(_Home.Length);
            Console.ReadKey();
        }
    }
}