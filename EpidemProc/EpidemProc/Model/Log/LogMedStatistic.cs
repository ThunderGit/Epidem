using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Model.Log
{
	class LogMedStatistic
	{
		public int Id { get; set; }
		public int Iteration { get; set; }
		public int CountOfHealthy { get; set; }
		public int CountOfInfected { get; set; }
		public int CountOfCritical { get; set; }
	}
}