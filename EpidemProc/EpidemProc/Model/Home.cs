using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Models
{
    class Home
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
		public int HospitalId { get; set; }

        public static SqlCommand PrepareCommand(SqlCommand command)
        {
            Home _home = new Home();
            command.CommandText = @"SELECT ID, X, Y, HOSPITAL_ID from dbo.HOME";

            command.Parameters.Add("ID",			SqlDbType.Int).Value = _home.Id;
            command.Parameters.Add("X",				SqlDbType.Int).Value = _home.X;
            command.Parameters.Add("Y",				SqlDbType.Int).Value = _home.Y;
			command.Parameters.Add("HOSPITAL_ID",	SqlDbType.Int).Value = _home.HospitalId;
			return command;
        }
        public static Home Get(SqlDataReader reader)
        {
            int i = 0;
            return new Home
            {
                Id = reader.GetInt32(i++),
                X = reader.GetInt32(i++),
                Y = reader.GetInt32(i++),
				HospitalId = reader.GetInt32(i++)
			};
        }
    }
}
