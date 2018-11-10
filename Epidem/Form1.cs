using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Epidem
{
    public partial class Form1 : Form
    {

        class Virus
        {
            //Характеритсики
            //int HeatProof = 0;
            //int ColdProof = 0;
            //int AirEffect = 0;
            //int BloodEffect = 0;
            //int TouchEffect = 0;
            //int CattleEffect = 0;
            //int BirdEffect = 0;
            //int InsectEffect = 0;
            //int PetEffect = 0;
            //int RodentEffect = 0;
            //int Mutation = 0;
            //int Mortality = 0;
            //int WaterEffect = 0;
            //int Heaviness = 0;
            ////Остальное
            //int HostlessLifespan = 0;
            //int death_Min_Tempr = 0;
            //int death_Max_Tempr = 0;
            //double SpreadSpeed = 0;
            ////Системы
            //bool circulatory;
            //bool respiratory;
            //bool nervous;
            //bool digestive;
            //bool excretory;
            //bool muscular;
            //bool skeleton;
            //bool immune;
            ////
            //bool SexualEffect;
            //bool Aeroby;
        }
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            r1.Text = "";
            //Для подключения
            SqlConnectionStringBuilder connect =
                            new SqlConnectionStringBuilder();
            connect.InitialCatalog = "PANDEMIC_INC";
            connect.DataSource = @"ANDREW-ПК\SQLEXPRESS2";
            connect.ConnectTimeout = 120;
            connect.IntegratedSecurity = true;
            //Для команд

            // Создание открытого подключения
            using (SqlConnection cn = new SqlConnection())
            {
                try
                {
                    cn.ConnectionString = connect.ConnectionString;
                    cn.Open();
                    MessageBox.Show("Success!!");

                    
                    r1.Text += GetData(cn);
 
                    cn.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Cannot connect to db\n\n" + ex.Message);
                }
            } 
            
        }

        private static String GetData(SqlConnection cn)//Выудить данные из таблицы
        {
            string data = "";
            SqlCommand command = new SqlCommand();
            command.Connection = cn;
            command.CommandType = CommandType.Text;
            //Get Data
            string code = "", name = "", status = "",corrup = "";
            command.CommandText = "select CODE,NAME,CORRUPTION_LEVEL,STATUS from dbo.POLICE";
            command.Parameters.Add("CODE", SqlDbType.VarChar).Value = code;
            command.Parameters.Add("NAME", SqlDbType.VarChar).Value = name;
            command.Parameters.Add("CORRUPTION_LEVEL", SqlDbType.VarChar).Value = corrup;
            command.Parameters.Add("STATUS", SqlDbType.VarChar).Value = status;
            
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    code = reader.GetString(0);
                    name = reader.GetString(1);
                    corrup = Convert.ToString(reader.GetInt32(2));
                    status = reader.GetString(3);
                    data+=code + " " + name + " " +corrup+" "+ status+"\n";
                }
                return data;
            }
            return "fail";
        }
    }
}
