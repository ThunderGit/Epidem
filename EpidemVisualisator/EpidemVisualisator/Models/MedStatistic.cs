using System;
using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Models
{
	class MedStatistic
	{
		public int Id { get; set; }
		public int Iteration { get; set; }
		public int CountOfHealthy { get; set; }
		public int CountOfInfected { get; set; }
		public int CountOfCritical { get; set; }

		public static SqlCommand PrepareCommand(SqlCommand command)
		{
			MedStatistic medStatistic = new MedStatistic();
			command.CommandText = @"SELECT ID, ITERRATION, COUNT_OF_HEALTHY, COUNT_OF_INFECTED, COUNT_OF_CRITICAL FROM dbo.LOG_MED_STATISTICK";

			command.Parameters.Add("ID",				SqlDbType.Int).Value = medStatistic.Id;
			command.Parameters.Add("ITERRATION",		SqlDbType.Int).Value = medStatistic.Iteration;
			command.Parameters.Add("COUNT_OF_HEALTHY",	SqlDbType.Bit).Value = medStatistic.CountOfHealthy;
			command.Parameters.Add("COUNT_OF_INFECTED", SqlDbType.Int).Value = medStatistic.CountOfInfected;
			command.Parameters.Add("COUNT_OF_CRITICAL", SqlDbType.Int).Value = medStatistic.CountOfCritical;
			return command;
		}
		public static MedStatistic Get(SqlDataReader reader)
		{
			int i = 0;
			return new MedStatistic
			{
				Id = reader.GetInt32(i++),
				Iteration = reader.GetInt32(i++),
				CountOfHealthy = reader.GetInt32(i++),
				CountOfInfected = reader.GetInt32(i++),
				CountOfCritical = reader.GetInt32(i++)
			};
		}

	}
}