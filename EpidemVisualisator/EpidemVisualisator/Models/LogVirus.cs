using System;
using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Models
{
	class LogVirus
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
       




    }
}