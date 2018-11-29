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
    class Loader
    {
        static private SqlConnection cn;
        public Loader(string ServerName, string DatabaseName)
        {
            SqlConnectionStringBuilder connect =
                           new SqlConnectionStringBuilder();
            connect.InitialCatalog = DatabaseName;
            connect.DataSource = ServerName;
            connect.ConnectTimeout = 120;
            connect.IntegratedSecurity = true;
            // Создание открытого подключения
            cn = new SqlConnection();
            cn.ConnectionString = connect.ConnectionString;
        }

        public void Load(ref Citizen[] All, ref Citizen[] Infected, ref Citizen[] Healthy, ref Policeman[] P, ref Doctor[] D, ref Troop[] T, ref Police[] _Police,
    ref Hospital[] _Hospital, ref Millitary[] _Military, ref Facture[] _Facture, ref Home[] _home)
        {
            try
            {
                //Вытягивание
                All = GetData<Citizen>(Citizen.PrepareCommand, Citizen.Get).ToArray();
                P = GetData<Policeman>(Policeman.PrepareCommand, Policeman.Get).ToArray();
                D = GetData<Doctor>(Doctor.PrepareCommand, Doctor.Get).ToArray();
                T = GetData<Troop>(Troop.PrepareCommand, Troop.Get).ToArray();
                _Police = GetData<Police>(Police.PrepareCommand, Police.Get).ToArray();
                _Hospital = GetData<Hospital>(Hospital.PrepareCommand, Hospital.Get).ToArray();
                _Military = GetData<Millitary>(Millitary.PrepareCommand, Millitary.Get).ToArray();
                _Facture = GetData<Facture>(Facture.PrepareCommand, Facture.Get).ToArray();
                _home = GetData<Home>(Home.PrepareCommand, Home.Get).ToArray();

                List<Citizen> infectedList = new List<Citizen>();
                List<Citizen> healthyList = new List<Citizen>();
                foreach (Citizen citiz in All)
                {
                    if (citiz.WasSick) infectedList.Add(citiz);
                    else healthyList.Add(citiz);
                }
                Infected = infectedList.ToArray();
                Healthy = healthyList.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Citizen[] Load()
        {
            try
            {
                return GetData<Citizen>(Citizen.PrepareCommand, Citizen.Get).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        delegate T Get<T>(SqlDataReader reader);
        delegate SqlCommand PrepareCommand(SqlCommand command);
        private static List<T> GetData<T>(PrepareCommand PrepareCommand, Get<T> Get)
        {
            cn.Open();
            List<T>  EntryList = new List<T>();
            SqlCommand command = new SqlCommand();
            command.Connection = cn;
            command.CommandType = CommandType.Text;
            PrepareCommand(command);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    EntryList.Add(Get(reader));
                }
            }
            //Конец вытягивания
            reader.Close();
            cn.Close();
            return EntryList;
        }
    }
}
