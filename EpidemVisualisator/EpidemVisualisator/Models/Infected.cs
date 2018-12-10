using System;
using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Models
{
	class Infected
	{
		public int Id { get; set; }
		public int Iteration { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int CountOfInfected { get; set; }
		public int CountOfHealthy { get; set; }


		public static SqlCommand PrepareCommand(SqlCommand command)
		{
			Infected infected = new Infected();
			command.CommandText = @"SELECT ID, ITERRATION, X, Y, COUNT_OF_INFECTED, COUNT_OF_HEALTHY FROM dbo.LOG_INFECTED";

			command.Parameters.Add("ID",					SqlDbType.Int).Value = infected.Id;
			command.Parameters.Add("ITERRATION",			SqlDbType.Int).Value = infected.Iteration;
			command.Parameters.Add("X",						SqlDbType.Int).Value = infected.X;
			command.Parameters.Add("Y",						SqlDbType.Int).Value = infected.Y;
			command.Parameters.Add("COUNT_OF_INFECTED",		SqlDbType.Int).Value = infected.CountOfInfected;
			command.Parameters.Add("COUNT_OF_HEALTHY",		SqlDbType.Int).Value = infected.CountOfHealthy;
			return command;
		}
		public static Infected Get(SqlDataReader reader)
		{
			int i = 0;
			return new Infected
			{
				Id = reader.GetInt32(i++),
				Iteration = reader.GetInt32(i++),
				X = reader.GetInt32(i++),
				Y = reader.GetInt32(i++),
				CountOfInfected = reader.GetInt32(i++),
				CountOfHealthy = reader.GetInt32(i++),
			};
		}
	}
}