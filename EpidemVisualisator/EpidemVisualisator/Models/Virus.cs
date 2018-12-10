using System;
using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Models
{
	class Virus
	{
		public int Id { get; set; }
		public int Iteration { get; set; }
		public int Difficult { get; set; }
		public int MinInfectT { get; set; }
		public int MaxInfectT { get; set; }
		public int MinComfortT { get; set; }
		public int MaxComfortT { get; set; }
		public int WetProtect { get; set; }
		public int skeletonDamaged { get; set; }
		public int muscleDamaged { get; set; }
		public int respiratoryDamaged { get; set; }
		public int circulatoryDamaged { get; set; }
		public int diureticDamaged { get; set; }
		public int digestiveDamaged { get; set; }
		public int nervousDamaged { get; set; }
		public int reproductiveDamaged { get; set; }
		public int sensoryDamaged { get; set; }
		public int lyphaticDamaged { get; set; }
		public int immunityDamaged { get; set; }


		public static SqlCommand PrepareCommand(SqlCommand command)
		{
			Virus virus = new Virus();
			command.CommandText = @"SELECT ID, ITERRATION, DIFFICULT, MININFECTT, MAXINFECTT, MINCOMFORTT, MAXCOMFORTT, WETPROTECT,
            SKELETONDAMAGED, MUSCLEDAMAGED, RESPIRATORYDAMAGED, CIRCULATORYDAMAGED, DIURETICDAMAGED, DIGESTIVEDAMAGED, NERVOUSDAMAGED,
            REPRODUCTIVEDAMAGED, SENSORYDAMAGED, LYPHATICDAMAGED, IMMUNITYDAMAGED FROM dbo.LOGvirus";

			command.Parameters.Add("ID",					SqlDbType.Int).Value = virus.Id;
			command.Parameters.Add("ITERRATION",			SqlDbType.Int).Value = virus.Iteration;
			command.Parameters.Add("DIFFICULT",				SqlDbType.Int).Value = virus.Difficult;
			command.Parameters.Add("MININFECTT",			SqlDbType.Int).Value = virus.MinInfectT;
			command.Parameters.Add("MAXINFECTT",			SqlDbType.Int).Value = virus.MaxInfectT;
			command.Parameters.Add("MINCOMFORTT",			SqlDbType.Int).Value = virus.MinComfortT;
			command.Parameters.Add("MAXCOMFORTT",			SqlDbType.Int).Value = virus.MaxComfortT;
			command.Parameters.Add("WETPROTECT",			SqlDbType.Int).Value = virus.WetProtect;
			command.Parameters.Add("SKELETONDAMAGED",		SqlDbType.Int).Value = virus.skeletonDamaged;
			command.Parameters.Add("MUSCLEDAMAGED",			SqlDbType.Int).Value = virus.muscleDamaged;
			command.Parameters.Add("RESPIRATORYDAMAGED",	SqlDbType.Int).Value = virus.respiratoryDamaged;
			command.Parameters.Add("CIRCULATORYDAMAGED",	SqlDbType.Int).Value = virus.circulatoryDamaged;
			command.Parameters.Add("DIURETICDAMAGED",		SqlDbType.Int).Value = virus.diureticDamaged;
			command.Parameters.Add("NERVOUSDAMAGED",		SqlDbType.Int).Value = virus.digestiveDamaged;
			command.Parameters.Add("REPRODUCTIVEDAMAGED",	SqlDbType.Int).Value = virus.reproductiveDamaged;
			command.Parameters.Add("SENSORYDAMAGED",		SqlDbType.Int).Value = virus.sensoryDamaged;
			command.Parameters.Add("LYPHATICDAMAGED",		SqlDbType.Int).Value = virus.lyphaticDamaged;
			command.Parameters.Add("IMMUNITYDAMAGED",		SqlDbType.Int).Value = virus.immunityDamaged;
			return command;
		}
		public static Virus Get(SqlDataReader reader)
		{
			int i = 0;
			return new Virus
			{
				Id = reader.GetInt32(i++),
				Iteration = reader.GetInt32(i++),
				Difficult = reader.GetInt32(i++),
				MinInfectT = reader.GetInt32(i++),
				MaxInfectT = reader.GetInt32(i++),
				MinComfortT = reader.GetInt32(i++),
				MaxComfortT = reader.GetInt32(i++),
				WetProtect = reader.GetInt32(i++),
				skeletonDamaged = reader.GetInt32(i++),
				muscleDamaged = reader.GetInt32(i++),
				respiratoryDamaged = reader.GetInt32(i++),
				circulatoryDamaged = reader.GetInt32(i++),
				diureticDamaged = reader.GetInt32(i++),
				digestiveDamaged = reader.GetInt32(i++),
				nervousDamaged = reader.GetInt32(i++),
				reproductiveDamaged = reader.GetInt32(i++),
				sensoryDamaged = reader.GetInt32(i++),
				lyphaticDamaged = reader.GetInt32(i++),
				immunityDamaged = reader.GetInt32(i++)
			};
		}


	}
}