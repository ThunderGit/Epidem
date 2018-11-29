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
    ref Hospital[] _Hospital, ref Millitary[] _Military)
        {
            //Первоначальное хранилище  во время вытягивания
            List<Citizen> citizenList = new List<Citizen>();
            List<Policeman> policemanList = new List<Policeman>();
            List<Doctor> doctorList = new List<Doctor>();
            List<Troop> troopList = new List<Troop>();
            List<Police> policeList = new List<Police>();
            List<Hospital> hospitalList = new List<Hospital>();
            List<Millitary> militaryList = new List<Millitary>();


            try
            {
                cn.Open();

                //Вытягивание
                All = GetData<Citizen>(Citizen.PrepareCommand, Citizen.Get).ToArray();
                P = GetData<Policeman>(Policeman.PrepareCommand, Policeman.Get).ToArray();
                D = GetData<Doctor>(Doctor.PrepareCommand, Doctor.Get).ToArray();
                T = GetData<Troop>(Troop.PrepareCommand, Troop.Get).ToArray();
                _Police = GetData<Police>(Police.PrepareCommand, Police.Get).ToArray();
                _Hospital = GetData<Hospital>(Hospital.PrepareCommand, Hospital.Get).ToArray();
                _Military = GetData<Millitary>(Millitary.PrepareCommand, Millitary.Get).ToArray();

                List<Citizen> infectedList = new List<Citizen>();
                List<Citizen> healthyList = new List<Citizen>();
                foreach (Citizen citiz in All)
                {
                    if (citiz.WasSick) infectedList.Add(citiz);
                    else healthyList.Add(citiz);
                }
                Infected = infectedList.ToArray();
                Healthy = healthyList.ToArray();

                Console.WriteLine("Success\n");
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!\n" + ex.Message);
            }

        }


        delegate T Get<T>(SqlDataReader reader);
        delegate SqlCommand PrepareCommand(SqlCommand command);
        private static List<T> GetData<T>(PrepareCommand PrepareCommand, Get<T> Get)
        {
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
            return EntryList;
        }
    }
}
