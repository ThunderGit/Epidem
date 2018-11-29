using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EpidemProc
{
    class Program
    {
        //static Table[] All;
        static Citizen[] All;
        static Citizen[] Infected;
        static Citizen[] Healthy;
        static Policeman[] P;
        static Doctor[] D;
        static Troop[] T ;
        static Police[] _Police;
        static Hospital[] _Hospital;
        static Millitary[] _Millitary;

        static void LoadData()
        {
            All = null;
            Infected = null;
            Healthy = null;
            P = null;
            D = null;
            T = null;
            _Police = null;
            _Hospital = null;
            _Millitary = null;
            Loader loader = new Loader(@"DESKTOP-SH16UUG", "PANDEMIC_INC");
            loader.Load(ref All, ref Infected, ref Healthy, ref P, ref D, ref T, ref _Police, ref _Hospital, ref _Millitary);
            //All = loader.Load<Citizen>();
        }

        static void Main(string[] args)
        {
            //нужно достать эти данные

            LoadData();
            Console.WriteLine(All.Length);
            Console.WriteLine(P.Length);
            Console.WriteLine(D.Length);
            Console.WriteLine(T.Length);
            Console.WriteLine(_Police.Length);
            Console.WriteLine(_Hospital.Length);
            Console.WriteLine(_Millitary.Length);
            Console.ReadKey();
        }
    }
}