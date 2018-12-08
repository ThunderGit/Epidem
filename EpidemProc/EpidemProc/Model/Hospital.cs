using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Models
{
    class Hospital
    {
        public int Id { get; set; }
        public bool IsPrivate { get; set; }
        public int CorruptionLevel { get; set; }
        public int MaxHospitalized { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public static SqlCommand PrepareCommand(SqlCommand command)
        {
            Hospital _hospital = new Hospital();
            command.CommandText = @"select ID, IS_PRIVATE, CORRUPTION_LEVEL, COUNT_OF_MAX_HOSPITALIZED, X, Y from dbo.HOSPITAL";

            command.Parameters.Add("ID",                        SqlDbType.Int).Value = _hospital.Id;
            command.Parameters.Add("CORRUPTION_LEVEL",          SqlDbType.Int).Value = _hospital.CorruptionLevel;
            command.Parameters.Add("COUNT_OF_MAX_HOSPITALIZED", SqlDbType.Int).Value = _hospital.MaxHospitalized;
            command.Parameters.Add("X",                         SqlDbType.Int).Value = _hospital.X;
            command.Parameters.Add("Y",                         SqlDbType.Int).Value = _hospital.Y;
            return command;
        }
        public static Hospital Get(SqlDataReader reader)
        {
            int i = 0;
            return new Hospital
            {
                Id = reader.GetInt32(i++),
                CorruptionLevel = reader.GetInt32(i++),
                MaxHospitalized = reader.GetInt32(i++),
                X = reader.GetInt32(i++),
                Y = reader.GetInt32(i++)
            };
        }
    }
}
