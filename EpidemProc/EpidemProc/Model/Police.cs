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
    class Police
    {
        public int Id { get; set; }
        public int CorruptionLevel { get; set; }
        public int Status { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public static SqlCommand PrepareCommand(SqlCommand command)
        {
            Police _police = new Police();//Гражданин

            command.CommandText = @"select ID, CORRUPTION_LEVEL, STATUS, X, Y from dbo.POLICE";

            command.Parameters.Add("ID",                SqlDbType.Int).Value = _police.Id;
            command.Parameters.Add("CORRUPTION_LEVEL",  SqlDbType.Int).Value = _police.CorruptionLevel;
            command.Parameters.Add("STATUS",            SqlDbType.Int).Value = _police.Status;
            command.Parameters.Add("X",                 SqlDbType.Int).Value = _police.X;
            command.Parameters.Add("Y",                 SqlDbType.Int).Value = _police.Y;
            return command;
        }
        public static Police Get(SqlDataReader reader)
        {
            int i = 0;
            return new Police
            {
                Id = reader.GetInt32(i++),
                CorruptionLevel = reader.GetInt32(i++),
                Status = reader.GetInt32(i++),
                X = reader.GetInt32(i++),
                Y = reader.GetInt32(i++)
            };
        }
    }
}
