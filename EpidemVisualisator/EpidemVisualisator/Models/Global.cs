using System;
using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Models
{
	class Global
	{
		public int Id { get; set; }
		public int Iteration { get; set; }
		public int CurrentHour { get; set; }
		public int CurrentDay { get; set; }
		public int RegPopulation { get; set; }
		public int CountOfInfected { get; set; }
		public int CountOfHealthy { get; set; }
		public int CountOfDeath { get; set; }
		public int CountOfPolicemans { get; set; }
		public int CountOfSoldiers { get; set; }
		public int CountOfDoctors { get; set; }
		public int Temperature { get; set; }
		public int Wet { get; set; }
		public int Research { get; set; }
		public int RegStatus { get; set; }

		public static SqlCommand PrepareCommand(SqlCommand command)
		{
			Global global = new Global();
			command.CommandText = @"SELECT ID, ITERRATION, CURRENT_HOUR, CURRENT_DAY, REG_POPULATION, COUNT_OF_INFECTED, COUNT_OF_HEALTHY, 
          COUNT_OF_DEATH, COUNT_OF_POLICEMANS, COUNT_OF_SOLDIERS, COUNT_OF_DOCTORS, TEMPERATURE, WET, RESEARCH, REG_STATUSFROM dbo.LOG_GLOBAL";

			command.Parameters.Add("ID", SqlDbType.Int).Value = global.Id;
			command.Parameters.Add("ITERRATION", SqlDbType.Int).Value = global.Iteration;
			command.Parameters.Add("CURRENT_HOUR", SqlDbType.Bit).Value = global.CurrentHour;
			command.Parameters.Add("CURRENT_DAY", SqlDbType.Int).Value = global.CurrentDay;
			command.Parameters.Add("REG_POPULATION", SqlDbType.Int).Value = global.RegPopulation;
			command.Parameters.Add("COUNT_OF_INFECTED", SqlDbType.Int).Value = global.CountOfInfected;
			command.Parameters.Add("COUNT_OF_HEALTHY", SqlDbType.Bit).Value = global.CountOfHealthy;
			command.Parameters.Add("COUNT_OF_DEATH", SqlDbType.Bit).Value = global.CountOfDeath;
			command.Parameters.Add("COUNT_OF_POLICEMANS", SqlDbType.Bit).Value = global.CountOfPolicemans;
			command.Parameters.Add("COUNT_OF_SOLDIERS", SqlDbType.Int).Value = global.CountOfSoldiers;
			command.Parameters.Add("COUNT_OF_DOCTORS", SqlDbType.Int).Value = global.CountOfDoctors;
			command.Parameters.Add("TEMPERATURE", SqlDbType.Int).Value = global.Temperature;
			command.Parameters.Add("WET", SqlDbType.Int).Value = global.Wet;
			command.Parameters.Add("RESEARCH", SqlDbType.Int).Value = global.Research;
			command.Parameters.Add("REG_STATUSFROM", SqlDbType.Int).Value = global.RegStatus;
			return command;
		}
		public static Global Get(SqlDataReader reader)
		{
			int i = 0;
			return new Global
			{
				Id = reader.GetInt32(i++),
				Iteration = reader.GetInt32(i++),
				CurrentHour = reader.GetInt32(i++),
				CurrentDay = reader.GetInt32(i++),
				RegPopulation = reader.GetInt32(i++),
				CountOfInfected = reader.GetInt32(i++),
				CountOfHealthy = reader.GetInt32(i++),
				CountOfDeath = reader.GetInt32(i++),
				CountOfPolicemans = reader.GetInt32(i++),
				CountOfSoldiers = reader.GetInt32(i++),
				CountOfDoctors = reader.GetInt32(i++),
				Temperature = reader.GetInt32(i++),
				Wet = reader.GetInt32(i++),
				Research = reader.GetInt32(i++),
				RegStatus = reader.GetInt32(i++)
			};
		}


	}


}