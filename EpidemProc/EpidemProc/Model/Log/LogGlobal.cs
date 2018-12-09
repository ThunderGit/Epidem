using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Model.Log
{
	class LogGlobal
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
	}
}