using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Models
{
    class Policeman
    {
        public int Id { get; set; }
        public int CitizenId { get; set; }
        public int PoliceId { get; set; }
        public bool Initiative { get; set; }
        public int Quality { get; set; }


        public static SqlCommand PrepareCommand(SqlCommand command)
        {
            Policeman _policeman = new Policeman();//Гражданин

            command.CommandText = @"select ID, CITIZENS_ID, POLICE_ID, INICIATIVE, QUALITY from POLICEMAN";

            command.Parameters.Add("ID",            SqlDbType.Int).Value = _policeman.CitizenId;
            command.Parameters.Add("CITIZENS_ID",   SqlDbType.Int).Value = _policeman.CitizenId;
            command.Parameters.Add("POLICE_ID",     SqlDbType.Int).Value = _policeman.PoliceId;
            command.Parameters.Add("INICIATIVE",    SqlDbType.Bit).Value = _policeman.Initiative;
            command.Parameters.Add("QUALITY",       SqlDbType.Int).Value = _policeman.Quality;
            return command;
        }
        public static Policeman Get(SqlDataReader reader)
        {
            int i = 0;
            return new Policeman
            {
                Id          = reader.GetInt32(i++),
                CitizenId   = reader.GetInt32(i++),
                PoliceId    = reader.GetInt32(i++),
                Initiative  = reader.GetBoolean(i++),
                Quality     = reader.GetInt32(i++)
            };
        }
    }
}
