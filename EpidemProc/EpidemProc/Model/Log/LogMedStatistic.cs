using System;
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

        public void SaveToDB()
        {
            
            int iter = this.Iteration;
            int CofH = this.CountOfHealthy;
            int CofI = this.CountOfInfected;
            int CofC = this.CountOfCritical;
            
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
        
                    using (SqlCommand cmd = new SqlCommand(@"INSERT INTO LOG_MED_STATISTICK (ITERRATION, COUNT_OF_HEALTHY, COUNT_OF_INFECTED, COUNT_OF_CRITICAL) 
VALUES (@iter, @CofH, @CofI, @CofC)", cn))
                {
                    
                    cmd.Parameters.AddWithValue("@iter", iter);
                    cmd.Parameters.AddWithValue("@CofH", CofH);
                    cmd.Parameters.AddWithValue("@CofI", CofI);
                    cmd.Parameters.AddWithValue("@CofC", CofC);

                    cmd.ExecuteNonQuery();
                }

                    //прошла жара

 
                    cn.Close();
                }
                catch(Exception ex)
                {
                   System.Console.WriteLine("Cannot connect to db\n\n" + ex.Message);
                }
            } 
            
        }

      }
}