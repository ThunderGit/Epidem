using System;
using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Model.Log
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
        public void SaveToDB()
        {

            int iter = this.Iteration;
            int D = this.Difficult;
            int MinInT = this.MinInfectT;
            int MaxInT = this.MaxInfectT;
            int MinComfT = this.MinComfortT;
            int MaxComfT = this.MaxComfortT;
            int WP = this.WetProtect;
            int SkelD = this.skeletonDamaged;
            int MD = this.muscleDamaged;
            int ResD = this.respiratoryDamaged;
            int CD = this.circulatoryDamaged;
            int DiuD = this.diureticDamaged;
            int DIfD = this.digestiveDamaged;
            int nD = this.nervousDamaged;
            int RepD = this.reproductiveDamaged;

            int SensD = this.sensoryDamaged;
            int LD = this.lyphaticDamaged;
            int ImD = this.immunityDamaged;


            SqlConnectionStringBuilder connect =
                            new SqlConnectionStringBuilder();
            connect.InitialCatalog = "PANDEMIC_INC";
            connect.DataSource = @"DESKTOP-SH16UUG";
            connect.ConnectTimeout = 120;
            connect.IntegratedSecurity = true;


            // Создание открытого подключения
            using (SqlConnection cn = new SqlConnection())
            {
                try
                {
                    cn.ConnectionString = connect.ConnectionString;
                    cn.Open();
                    System.Console.WriteLine("SUCCESS!");//уберёшь потом если что


                    //пошла жара

                    SqlCommand command = new SqlCommand();
                    command.Connection = cn;
                    command.CommandType = CommandType.Text;
                    //Insert Data

                    using (SqlCommand cmd = new SqlCommand(@"INSERT INTO  VIRUS (ITERRATION,DIFFICULT,MININFECTT,MAXINFECTT,MINCOMFORTT,
MAXCOMFORTT,WETPROTECT,SKELETONDAMAGED,MUSCLEDAMAGED,RESPIRATORYDAMAGED,
CIRCULATORYDAMAGED,DIURETICDAMAGED,DIGESTIVEDAMAGED,
NERVOUSDAMAGED,REPRODUCTIVEDAMAGED,SENSORYDAMAGED,LYPHATICDAMAGED,IMMUNITYDAMAGED) 
VALUES ( @iter, @D, @MinInT,@MaxInT,@MinComfT,@MaxComfT,@WP,@SkelD,@MD,@ResD,@CD,@DiuD,@DIfD,@nD,
@RepD,@SensD,@LD,@ImD)", cn))
                    {

                        cmd.Parameters.AddWithValue("@iter", iter);
                        cmd.Parameters.AddWithValue("@D", D);
                        cmd.Parameters.AddWithValue("@MinInT", MinInT);
                        cmd.Parameters.AddWithValue("@MaxInT", MaxInT);
                        cmd.Parameters.AddWithValue("@MinComfT", MinComfT);
                        cmd.Parameters.AddWithValue("@MaxComfT", MaxComfT);
                        cmd.Parameters.AddWithValue("@WP", WP);
                        cmd.Parameters.AddWithValue("@SkelD", SkelD);
                        cmd.Parameters.AddWithValue("@MD", MD);
                        cmd.Parameters.AddWithValue("@ResD", ResD);
                        cmd.Parameters.AddWithValue("@CD", CD);
                        cmd.Parameters.AddWithValue("@DiuD", DiuD);
                        cmd.Parameters.AddWithValue("@DIfD", DIfD);
                        cmd.Parameters.AddWithValue("@nD", nD);
                        cmd.Parameters.AddWithValue("@RepD", RepD);
                        cmd.Parameters.AddWithValue("@SensD", SensD);
                        cmd.Parameters.AddWithValue("@LD", LD);
                        cmd.Parameters.AddWithValue("@ImD", ImD);

                        cmd.ExecuteNonQuery();
                    }

                    //прошла жара


                    cn.Close();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Cannot connect to db\n\n" + ex.Message);
                }
            }

        }



    }
}