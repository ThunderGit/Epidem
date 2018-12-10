using System;
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

        public void SaveToDB()
        {
            
            int iter = this.Iteration;
            int CH = this.CurrentHour;
            int CD = this.CurrentDay;
            int RG = this.RegPopulation;

            int CofH = this.CountOfHealthy;
            int CofI = this.CountOfInfected;
            int Cofd = this.CountOfDeath;
            int CofP = this.CountOfPolicemans;
            int CofS = this.CountOfSoldiers;
            int CofDocs = this.CountOfDoctors;

            int temp = this.Temperature;
            int w = this.Wet;
            int R = this.Research;
            int RS = this.RegStatus;


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

                    using (SqlCommand cmd = new SqlCommand(@"INSERT INTO 
TABLE LOG_GLOBAL (ITERRATION, CURRENT_HOUR, COUNT_OF_HEALTHY, CURRENT_DAY, REG_POPULATION,
COUNT_OF_INFECTED, COUNT_OF_HEALTHY,COUNT_OF_DEATH,COUNT_OF_POLICEMANS,COUNT_OF_SOLDIERS,COUNT_OF_DOCTORS,
TEMPERATURE,WET,RESEARCH,REG_STATUS) 
VALUES ( @iter, @CH, @CD, @RG,@CofI,@CofH,@Cofd,@CofP,@CofS,@CofDocs,@temp,@w,@R,@RS)", cn))
                    {
                        
                        cmd.Parameters.AddWithValue("@iter", iter);
                        cmd.Parameters.AddWithValue("@CH", CH);
                        cmd.Parameters.AddWithValue("@CD", CD);
                        cmd.Parameters.AddWithValue("@RG", RG);
                        cmd.Parameters.AddWithValue("@CofI", CofI);
                        cmd.Parameters.AddWithValue("@CofH", CofH);
                        cmd.Parameters.AddWithValue("@Cofd", Cofd);
                        cmd.Parameters.AddWithValue("@CofP", CofP);
                        cmd.Parameters.AddWithValue("@CofS", CofS);
                        cmd.Parameters.AddWithValue("@CofDocs", CofDocs);
                        cmd.Parameters.AddWithValue("@temp", temp);
                        cmd.Parameters.AddWithValue("@w", w);
                        cmd.Parameters.AddWithValue("@R", R);
                        cmd.Parameters.AddWithValue("@RS",RS);

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