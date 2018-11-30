using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Models
{
    class Facture
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public static SqlCommand PrepareCommand(SqlCommand command)
        {
            Facture _facture = new Facture();
            command.CommandText = @"SELECT ID, X, Y from dbo.FACTURE";

            command.Parameters.Add("ID", SqlDbType.Int).Value = _facture.Id;
            command.Parameters.Add("X",  SqlDbType.Int).Value = _facture.X;
            command.Parameters.Add("Y",  SqlDbType.Int).Value = _facture.Y;
            return command;
        }
        public static Facture Get(SqlDataReader reader)
        {
            int i = 0;
            return new Facture
            {
                Id = reader.GetInt32(i++),
                X = reader.GetInt32(i++),
                Y = reader.GetInt32(i++)
            };
        }
    }
}
