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





        static void Load(ref Citizen[] All,ref Citizen[]Infected,ref Citizen[]Healthy, ref Policeman[] P, ref Doctor[] D, ref Troop[] T,ref Police[] _Police,
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

          
            //Для подключения
            SqlConnectionStringBuilder connect =
                            new SqlConnectionStringBuilder();
            connect.InitialCatalog = "PANDEMIC_INC";
            connect.DataSource = @"ANDREW-ПК\SQLEXPRESS2";
            connect.ConnectTimeout = 120;
            connect.IntegratedSecurity = true;
            // Создание открытого подключения
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = connect.ConnectionString;
                cn.Open();
               
                //Вытягивание
                All=GetData(citizenList, cn).ToArray();
                P = GetData(policemanList, cn).ToArray();
                D = GetData(doctorList, cn).ToArray();
                T = GetData(troopList, cn).ToArray();
                _Police = GetData(policeList, cn).ToArray();
                _Hospital = GetData(hospitalList, cn).ToArray();
                _Military = GetData(militaryList, cn).ToArray();

                List<Citizen> infectedList = new List<Citizen>();
                List<Citizen> healthyList = new List<Citizen>();
                foreach(Citizen citiz in All)
                {
                    if (citiz.WasSick) infectedList.Add(citiz);
                    else healthyList.Add(citiz);
                }
                Infected = infectedList.ToArray();
                Healthy = healthyList.ToArray();

                Console.WriteLine("Success\n");
                cn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error!\n" + ex.Message);
            }

        }

        private static List<Citizen> GetData(List<Citizen> citizenList, SqlConnection cn)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cn;
            command.CommandType = CommandType.Text;

            Citizen _citizen = new Citizen();//Гражданин

            command.CommandText = @"select IMMUNITY,WASSICK,SOCIALSTATUS,PROFFESIONID,HEALTH,HEALTHSTATUS,
HARDWORKER,SICKLEAVE,HOSPITALIZED,FACTUREID,X,Y from dbo.CITIZENS";

            command.Parameters.Add("IMMUNITY", SqlDbType.Int).Value = _citizen.Immunity;
            command.Parameters.Add("WASSICK", SqlDbType.Bit).Value = _citizen.WasSick;
            command.Parameters.Add("SocialStatus", SqlDbType.VarChar).Value = _citizen.SocialStatus;
            command.Parameters.Add("PROFFESIONID", SqlDbType.Int).Value = _citizen.ProffesionId;
            command.Parameters.Add("HEALTH", SqlDbType.Int).Value = _citizen.Health;
            command.Parameters.Add("HEALTHSTATUS", SqlDbType.Int).Value = _citizen.HealthStatus;
            command.Parameters.Add("HARDWORKER", SqlDbType.Bit).Value = _citizen.HardWorker;
            command.Parameters.Add("SICKLEAVE", SqlDbType.Bit).Value = _citizen.SickLeave;
            command.Parameters.Add("HOSPITALIZED", SqlDbType.Bit).Value = _citizen.Hospitalized;
            command.Parameters.Add("FACTUREID", SqlDbType.Int).Value = _citizen.FactureId;
            command.Parameters.Add("X", SqlDbType.Int).Value = _citizen.X;
            command.Parameters.Add("Y", SqlDbType.Int).Value = _citizen.Y;

            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)//Если есть записи
            {
                int i = 0;//Чтоб не париться с номером столбца

                while (reader.Read())
                {
                    i = 0;//Каждый раз...
                    _citizen = new Citizen();//... новая запись

                    _citizen.Immunity = reader.GetInt32(i++);
                    _citizen.WasSick = reader.GetBoolean(i++);
                    _citizen.SocialStatus = reader.GetString(i++);
                    _citizen.ProffesionId = reader.GetInt32(i++);
                    _citizen.Health = reader.GetInt32(i++);
                    _citizen.HealthStatus = reader.GetInt32(i++);
                    _citizen.HardWorker = reader.GetBoolean(i++);
                    _citizen.SickLeave = reader.GetBoolean(i++);
                    _citizen.Hospitalized = reader.GetBoolean(i++);
                    _citizen.FactureId = reader.GetInt32(i++);
                    _citizen.X = reader.GetInt32(i++);
                    _citizen.Y = reader.GetInt32(i++);

                    //Добавление нового гражданина
                    citizenList.Add(_citizen);
                }

            }
            //Конец вытягивания
            return citizenList;
        }

        private static List<Policeman> GetData(List<Policeman> policemanList, SqlConnection cn)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cn;
            command.CommandType = CommandType.Text;

            Policeman _policeman = new Policeman();//Гражданин

            command.CommandText = @"select CITIZENS_ID,POLICE_ID,INICIATIVE,QUALITY from dbo.POLICEMAN";

            command.Parameters.Add("CITIZENS_ID", SqlDbType.Int).Value = _policeman.CitizenId;
            command.Parameters.Add("POLICE_ID", SqlDbType.Int).Value = _policeman.PoliceId;
            command.Parameters.Add("INICIATIVE", SqlDbType.Bit).Value = _policeman.Initiative;
            command.Parameters.Add("QUALITY", SqlDbType.Int).Value = _policeman.Quality;
           

            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)//Если есть записи
            {
                int i = 0;//Чтоб не париться с номером столбца

                while (reader.Read())
                {
                    i = 0;//Каждый раз...
                    _policeman = new Policeman();//... новая запись

                    _policeman.CitizenId = reader.GetInt32(i++);
                    _policeman.PoliceId = reader.GetInt32(i++);
                    _policeman.Initiative = reader.GetBoolean(i++);
                    _policeman.Quality = reader.GetInt32(i++);
                    

                    //Добавление нового гражданина
                    policemanList.Add(_policeman);
                }

            }
            //Конец вытягивания
            return policemanList;
        }

        private static List<Doctor> GetData(List<Doctor> doctorList, SqlConnection cn)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cn;
            command.CommandType = CommandType.Text;

            Doctor _doctor = new Doctor();//Гражданин

            command.CommandText = @"select CITIZENS_ID,HOSPITAL_ID,INICIATIVE,QUALITY from dbo.DOCTORS";

            command.Parameters.Add("CITIZENS_ID", SqlDbType.Int).Value = _doctor.CitizenId;
            command.Parameters.Add("HOSPITAL_ID", SqlDbType.Int).Value = _doctor.HospitalId;
            command.Parameters.Add("INICIATIVE", SqlDbType.Bit).Value = _doctor.Initiative;
            command.Parameters.Add("QUALITY", SqlDbType.Int).Value = _doctor.Quality;


            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)//Если есть записи
            {
                int i = 0;//Чтоб не париться с номером столбца

                while (reader.Read())
                {
                    i = 0;//Каждый раз...
                    _doctor = new Doctor();//... новая запись

                    _doctor.CitizenId = reader.GetInt32(i++);
                    _doctor.HospitalId = reader.GetInt32(i++);
                    _doctor.Initiative = reader.GetBoolean(i++);
                    _doctor.Quality = reader.GetInt32(i++);


                    //Добавление нового гражданина
                    doctorList.Add(_doctor);
                }

            }
            //Конец вытягивания
            return doctorList;
        }

        private static List<Troop> GetData(List<Troop> troopList, SqlConnection cn)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cn;
            command.CommandType = CommandType.Text;

            Troop _troop = new Troop();//Гражданин

            command.CommandText = @"select CITIZENS_ID,MILITARY_ID,INICIATIVE,QUALITY from dbo.TROOPS";

            command.Parameters.Add("CITIZENS_ID", SqlDbType.Int).Value = _troop.CitizenId;
            command.Parameters.Add("MILITARY_ID", SqlDbType.Int).Value = _troop.MilitaryId;
            command.Parameters.Add("INICIATIVE", SqlDbType.Bit).Value = _troop.Initiative;
            command.Parameters.Add("QUALITY", SqlDbType.Int).Value = _troop.Quality;


            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)//Если есть записи
            {
                int i = 0;//Чтоб не париться с номером столбца

                while (reader.Read())
                {
                    i = 0;//Каждый раз...
                    _troop = new Troop();//... новая запись

                    _troop.CitizenId = reader.GetInt32(i++);
                    _troop.MilitaryId = reader.GetInt32(i++);
                    _troop.Initiative = reader.GetBoolean(i++);
                    _troop.Quality = reader.GetInt32(i++);


                    //Добавление нового гражданина
                    troopList.Add(_troop);
                }

            }
            //Конец вытягивания
            return troopList;
        }

        private static List<Police> GetData(List<Police> policeList, SqlConnection cn)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cn;
            command.CommandType = CommandType.Text;

            Police _police = new Police();//Гражданин

            command.CommandText = @"select select CODE,NAME,CORRUPTION_LEVEL,STATUS,X,Y, from dbo.POLICE";

            command.Parameters.Add("CODE", SqlDbType.NVarChar).Value = _police.Code;
            command.Parameters.Add("NAME", SqlDbType.NVarChar).Value = _police.Name;
            command.Parameters.Add("CORRUPTION_LEVEL", SqlDbType.Int).Value = _police.CorruptionLevel;
            command.Parameters.Add("STATUS", SqlDbType.NVarChar).Value = _police.Status;
            command.Parameters.Add("X", SqlDbType.Int).Value = _police.X;
            command.Parameters.Add("Y", SqlDbType.Int).Value = _police.Y;


            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)//Если есть записи
            {
                int i = 0;//Чтоб не париться с номером столбца

                while (reader.Read())
                {
                    i = 0;//Каждый раз...
                    _police = new Police();//... новая запись

                    _police.Code = reader.GetString(i++);
                    _police.Name = reader.GetString(i++);
                    _police.CorruptionLevel = reader.GetInt32(i++);
                    _police.Status = reader.GetString(i++);
                    _police.X = reader.GetInt32(i++);
                    _police.Y = reader.GetInt32(i++);


                    //Добавление нового гражданина
                    policeList.Add(_police);
                }

            }
            //Конец вытягивания
            return policeList;
        }

        private static List<Hospital> GetData(List<Hospital> hospitalList, SqlConnection cn)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cn;
            command.CommandType = CommandType.Text;

            Hospital _hospital = new Hospital();//Гражданин

            command.CommandText = @"select select CODE,NAME,IS_PRIVATE,CORRUPTION_LEVEL,
COUNT_OF_MAX_HOSPITALIZED from dbo.HOSPITAL";

            command.Parameters.Add("CODE", SqlDbType.NVarChar).Value = _hospital.Code;
            command.Parameters.Add("NAME", SqlDbType.NVarChar).Value = _hospital.Name;
            command.Parameters.Add("IS_PRIVATE", SqlDbType.Bit).Value = _hospital.IsPrivate;
            command.Parameters.Add("CORRUPTION_LEVEL", SqlDbType.Int).Value = _hospital.CorruptionLevel;
            command.Parameters.Add("COUNT_OF_MAX_HOSPITALIZED", SqlDbType.Int).Value = _hospital.MaxHospitalized;


            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)//Если есть записи
            {
                int i = 0;//Чтоб не париться с номером столбца

                while (reader.Read())
                {
                    i = 0;//Каждый раз...
                    _hospital = new Hospital();//... новая запись

                    _hospital.Code = reader.GetString(i++);
                    _hospital.Name = reader.GetString(i++);
                    _hospital.IsPrivate = reader.GetBoolean(i++);
                    _hospital.CorruptionLevel = reader.GetInt32(i++);
                    _hospital.MaxHospitalized = reader.GetInt32(i++);
                    

                    //Добавление нового гражданина
                    hospitalList.Add(_hospital);
                }

            }
            //Конец вытягивания
            return hospitalList;
        }

        private static List<Millitary> GetData(List<Millitary> militaryList, SqlConnection cn)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cn;
            command.CommandType = CommandType.Text;

            Millitary _military = new Millitary();//Гражданин

            command.CommandText = @"select select CODE,NAME,IS_PRIVATE,CORRUPTION_LEVEL,STATUS from dbo.MILITARY";

            command.Parameters.Add("CODE", SqlDbType.NVarChar).Value = _military.Code;
            command.Parameters.Add("NAME", SqlDbType.NVarChar).Value = _military.Name;
            command.Parameters.Add("IS_PRIVATE", SqlDbType.Bit).Value = _military.IsPrivate;
            command.Parameters.Add("CORRUPTION_LEVEL", SqlDbType.Int).Value = _military.CorruptionLevel;
            command.Parameters.Add("STATUS", SqlDbType.NVarChar).Value = _military.Status;


            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)//Если есть записи
            {
                int i = 0;//Чтоб не париться с номером столбца

                while (reader.Read())
                {
                    i = 0;//Каждый раз...
                    _military = new Millitary();//... новая запись

                    _military.Code = reader.GetString(i++);
                    _military.Name = reader.GetString(i++);
                    _military.IsPrivate = reader.GetBoolean(i++);
                    _military.CorruptionLevel = reader.GetInt32(i++);
                    _military.Status = reader.GetString(i++);


                    //Добавление нового гражданина
                    militaryList.Add(_military);
                }

            }
            //Конец вытягивания
            return militaryList;
        }

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
            Load(ref All,ref Infected,ref Healthy, ref P, ref D, ref T, ref _Police, ref _Hospital, ref _Millitary);

        }
    }
}