using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EpidemProc.Models;

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

        public void Load(ref LogGlobal [] globals, ref LogMedStatistic[] medStatistics, ref LogVirus[] viruses, ref LogInfected[] infecteds)
        {
            try
            {
				//Вытягивание
				globals = GetData<LogGlobal>(LogGlobal.PrepareCommand, LogGlobal.Get).ToArray();
				medStatistics = GetData<LogMedStatistic>(LogMedStatistic.PrepareCommand, LogMedStatistic.Get).ToArray();
				viruses = GetData<LogVirus>(LogVirus.PrepareCommand, LogVirus.Get).ToArray();
				infecteds = GetData<LogInfected>(LogInfected.PrepareCommand, LogInfected.Get).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
