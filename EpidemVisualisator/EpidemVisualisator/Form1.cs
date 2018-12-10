using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpidemProc.Models;
using EpidemProc.Enum;
using EpidemProc;
namespace EpidemVisualisator
{
    public partial class Form1 : Form
    {
		Global[] global;
		Infected[] infecteds;
		MedStatistic[] medStatistics;
		Virus[] viruses;
        public Form1()
        {
			Loader loader = new Loader(@"DESKTOP-SH16UUG", "PANDEMIC_INC");
			loader.Load(ref global, ref medStatistics, ref viruses, ref infecteds);
			InitializeComponent();
        }

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void Starter_Click(object sender, EventArgs e)
		{
			
		}
	}
}
