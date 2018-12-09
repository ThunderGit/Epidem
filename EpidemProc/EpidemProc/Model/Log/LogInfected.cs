using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Model.Log
{
	class LogInfected
	{
		public int Id { get; set; }
		public int Iteration { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int CountOfInfected { get; set; }
		public int CountOfHealthy { get; set; }
	}
}