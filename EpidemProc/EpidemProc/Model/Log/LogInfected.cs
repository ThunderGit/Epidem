using System;
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
        
        public void SaveToDB()
        {

            int iter = this.Iteration;
            int x = this.X;
            int y = this.Y;
           
            int CofH = this.CountOfHealthy;
            int CofI = this.CountOfInfected;
   

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

                    using (SqlCommand cmd = new SqlCommand(@"INSERT INTO LOG_GLOBAL (ITERRATION, X,Y,COUNT_OF_INFECTED, COUNT_OF_HEALTHY) 
VALUES ( @iter, @x, @y,@CofI,@CofH)", cn))
                    {

                        cmd.Parameters.AddWithValue("@iter", iter);
                        cmd.Parameters.AddWithValue("@x", x);
                        cmd.Parameters.AddWithValue("@y", y);
                        cmd.Parameters.AddWithValue("@CofI", CofI);
                        cmd.Parameters.AddWithValue("@CofH", CofH);

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