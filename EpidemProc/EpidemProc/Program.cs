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
        private Citizen[] people;






        static void Main(string[] args)
        {
            //нужно достать эти данные
            Citizen[] All=null;
            Citizen[] Infected = null;
            Citizen[] Healthy = null;
            Policeman[] P = null;
            Doctor[] D = null;
            Troop[] T = null;
            Police[] _Police = null;
            Hospital[] _Hospital = null;
            Millitary[] _Millitary = null;


            Loader.Load(ref All,ref Infected,ref Healthy, ref P, ref D, ref T, ref _Police, ref _Hospital, ref _Millitary);
            Console.WriteLine(All.Length);
            Console.WriteLine(P.Length);
            Console.WriteLine(D.Length);
            Console.WriteLine(T.Length);
            Console.WriteLine(_Police.Length);
            Console.WriteLine(_Hospital.Length);
            Console.WriteLine(_Millitary.Length);
        }
    }
}