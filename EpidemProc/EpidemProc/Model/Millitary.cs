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
    class Millitary
    {
        public int Id { get; set; }
        public bool IsPrivate { get; set; }
        public int CorruptionLevel { get; set; }
        public int Status { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public static SqlCommand PrepareCommand(SqlCommand command)
        {
            Millitary _military = new Millitary();//Гражданин

            command.CommandText = @"select ID, IS_PRIVATE, CORRUPTION_LEVEL, STATUS, X, Y from dbo.MILITARY";

            command.Parameters.Add("ID",                SqlDbType.Int).Value = _military.Id;
            command.Parameters.Add("IS_PRIVATE",        SqlDbType.Bit).Value = _military.IsPrivate;
            command.Parameters.Add("CORRUPTION_LEVEL",  SqlDbType.Int).Value = _military.CorruptionLevel;
            command.Parameters.Add("STATUS",            SqlDbType.Int).Value = _military.Status;
            command.Parameters.Add("X",                 SqlDbType.Int).Value = _military.X;
            command.Parameters.Add("Y",                 SqlDbType.Int).Value = _military.Y;
            return command;
        }
        public static Millitary Get(SqlDataReader reader)
        {
            int i = 0;
            return new Millitary
            {
                Id = reader.GetInt32(i++),
                IsPrivate = reader.GetBoolean(i++),
                CorruptionLevel = reader.GetInt32(i++),
                Status = reader.GetInt32(i++),
                X = reader.GetInt32(i++),
                Y = reader.GetInt32(i++)
            };
        }
    }
}
