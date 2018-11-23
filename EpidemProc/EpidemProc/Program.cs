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

        static void Load()
        {
            //Для подключения
            SqlConnectionStringBuilder connect =
                            new SqlConnectionStringBuilder();
            connect.InitialCatalog = "PANDEMIC_INC";
            connect.DataSource = @"DESKTOP-SH16UUG";
            connect.ConnectTimeout = 120;
            connect.IntegratedSecurity = true;
            // Создание открытого подключения
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connect.ConnectionString;
            cn.Open();
            SqlCommand command = new SqlCommand();
           // int a = Select(); command.CommandText = "select CODE,NAME,CORRUPTION_LEVEL,STATUS from dbo.POLICE";
            cn.Close();





            //нужно достать эти данные
            Citizen[] All;
            Citizen[] Infected;
            Citizen[] Healthy;
            Policeman[] P;
            Doctor[] D;
            Troop[] T;


            Police[] Police;
            Hospital[] Hospital;
            Millitary[] Millitary;
        }
        static void Main(string[] args)
        {
        }
    }
}
