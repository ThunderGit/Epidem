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
    class Home
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public static SqlCommand PrepareCommand(SqlCommand command)
        {
            Home _home = new Home();
            command.CommandText = @"SELECT ID, X, Y from dbo.HOME";

            command.Parameters.Add("ID", SqlDbType.Int).Value = _home.Id;
            command.Parameters.Add("X",  SqlDbType.Int).Value = _home.X;
            command.Parameters.Add("Y",  SqlDbType.Int).Value = _home.Y;
            return command;
        }
        public static Home Get(SqlDataReader reader)
        {
            int i = 0;
            return new Home
            {
                Id = reader.GetInt32(i++),
                X = reader.GetInt32(i++),
                Y = reader.GetInt32(i++)
            };
        }
    }
}
