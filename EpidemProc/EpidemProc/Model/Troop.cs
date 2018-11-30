using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Models
{
    class Troop
    {
        public int Id { get; set; }
        public int CitizenId { get; set; }
        public int MilitaryId { get; set; }
        public bool Initiative { get; set; }
        public int Quality { get; set; }


        public static SqlCommand PrepareCommand(SqlCommand command)
        {
            Troop _troop = new Troop();//Гражданин

            command.CommandText = @"select ID, CITIZENS_ID, MILITARY_ID, INICIATIVE, QUALITY from dbo.TROOPS";

            command.Parameters.Add("ID",            SqlDbType.Int).Value = _troop.Id;
            command.Parameters.Add("CITIZENS_ID",   SqlDbType.Int).Value = _troop.CitizenId;
            command.Parameters.Add("MILITARY_ID",   SqlDbType.Int).Value = _troop.MilitaryId;
            command.Parameters.Add("INICIATIVE",    SqlDbType.Bit).Value = _troop.Initiative;
            command.Parameters.Add("QUALITY",       SqlDbType.Int).Value = _troop.Quality;
            return command;
        }
        public static Troop Get(SqlDataReader reader)
        {
            int i = 0;
            return new Troop
            {
                Id          = reader.GetInt32(i++),
                CitizenId   = reader.GetInt32(i++),
                MilitaryId  = reader.GetInt32(i++),
                Initiative  = reader.GetBoolean(i++),
                Quality     = reader.GetInt32(i++)
            };
        }
    }
}
