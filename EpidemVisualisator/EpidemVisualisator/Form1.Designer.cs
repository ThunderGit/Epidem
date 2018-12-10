namespace EpidemVisualisator
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.Starter = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.TimeText = new System.Windows.Forms.TextBox();
			this.WetText = new System.Windows.Forms.TextBox();
			this.DayTimeText = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.MedHealthyText = new System.Windows.Forms.TextBox();
			this.MedInfectedText = new System.Windows.Forms.TextBox();
			this.MedCriricalText = new System.Windows.Forms.TextBox();
			this.MedDeathText = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.PopulationText = new System.Windows.Forms.TextBox();
			this.RealDeathText = new System.Windows.Forms.TextBox();
			this.RealInfectedText = new System.Windows.Forms.TextBox();
			this.RealHealthyText = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.DoctorsCountText = new System.Windows.Forms.TextBox();
			this.PolicemanCountText = new System.Windows.Forms.TextBox();
			this.SoldiersCountText = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.ResearchText = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.StatusText = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 41);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(946, 403);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// Starter
			// 
			this.Starter.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.Starter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Starter.Location = new System.Drawing.Point(824, 554);
			this.Starter.Name = "Starter";
			this.Starter.Size = new System.Drawing.Size(129, 62);
			this.Starter.TabIndex = 1;
			this.Starter.Text = "Start Simulation";
			this.Starter.UseVisualStyleBackColor = true;
			this.Starter.Click += new System.EventHandler(this.Starter_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(7, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(278, 29);
			this.label1.TabIndex = 2;
			this.label1.Text = "Novomoskovsk region:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(287, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Temperature:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)), true);
			this.label3.Location = new System.Drawing.Point(459, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Wet:";
			// 
			// TimeText
			// 
			this.TimeText.BackColor = System.Drawing.SystemColors.Window;
			this.TimeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TimeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TimeText.Location = new System.Drawing.Point(399, 11);
			this.TimeText.Name = "TimeText";
			this.TimeText.Size = new System.Drawing.Size(51, 16);
			this.TimeText.TabIndex = 5;
			// 
			// WetText
			// 
			this.WetText.BackColor = System.Drawing.SystemColors.Window;
			this.WetText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.WetText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.WetText.Location = new System.Drawing.Point(506, 11);
			this.WetText.Name = "WetText";
			this.WetText.Size = new System.Drawing.Size(43, 16);
			this.WetText.TabIndex = 6;
			this.WetText.TextChanged += new System.EventHandler(this.WetText_TextChanged);
			// 
			// DayTimeText
			// 
			this.DayTimeText.BackColor = System.Drawing.SystemColors.Window;
			this.DayTimeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DayTimeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DayTimeText.Location = new System.Drawing.Point(824, 12);
			this.DayTimeText.Name = "DayTimeText";
			this.DayTimeText.Size = new System.Drawing.Size(134, 16);
			this.DayTimeText.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(83, 447);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(227, 29);
			this.label4.TabIndex = 8;
			this.label4.Text = "Global Information";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(566, 447);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(232, 29);
			this.label5.TabIndex = 9;
			this.label5.Text = "Official Information";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label6.Location = new System.Drawing.Point(587, 486);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(132, 17);
			this.label6.TabIndex = 10;
			this.label6.Text = "Count of healthy:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.label7.Location = new System.Drawing.Point(584, 508);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(137, 17);
			this.label7.TabIndex = 11;
			this.label7.Text = "Count of infected:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.ForeColor = System.Drawing.Color.Red;
			this.label8.Location = new System.Drawing.Point(529, 531);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(190, 17);
			this.label8.TabIndex = 12;
			this.label8.Text = "Count of critical infected:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label9.Location = new System.Drawing.Point(599, 552);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(120, 17);
			this.label9.TabIndex = 13;
			this.label9.Text = "Count of death:";
			// 
			// MedHealthyText
			// 
			this.MedHealthyText.BackColor = System.Drawing.SystemColors.Window;
			this.MedHealthyText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MedHealthyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MedHealthyText.Location = new System.Drawing.Point(725, 487);
			this.MedHealthyText.Name = "MedHealthyText";
			this.MedHealthyText.Size = new System.Drawing.Size(78, 16);
			this.MedHealthyText.TabIndex = 14;
			this.MedHealthyText.TextChanged += new System.EventHandler(this.MedHealthyText_TextChanged);
			// 
			// MedInfectedText
			// 
			this.MedInfectedText.BackColor = System.Drawing.SystemColors.Window;
			this.MedInfectedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MedInfectedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MedInfectedText.Location = new System.Drawing.Point(725, 509);
			this.MedInfectedText.Name = "MedInfectedText";
			this.MedInfectedText.Size = new System.Drawing.Size(78, 16);
			this.MedInfectedText.TabIndex = 15;
			this.MedInfectedText.TextChanged += new System.EventHandler(this.MedInfectedText_TextChanged);
			// 
			// MedCriricalText
			// 
			this.MedCriricalText.BackColor = System.Drawing.SystemColors.Window;
			this.MedCriricalText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MedCriricalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MedCriricalText.Location = new System.Drawing.Point(725, 531);
			this.MedCriricalText.Name = "MedCriricalText";
			this.MedCriricalText.Size = new System.Drawing.Size(78, 16);
			this.MedCriricalText.TabIndex = 16;
			this.MedCriricalText.TextChanged += new System.EventHandler(this.MedCriricalText_TextChanged);
			// 
			// MedDeathText
			// 
			this.MedDeathText.BackColor = System.Drawing.SystemColors.Window;
			this.MedDeathText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MedDeathText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MedDeathText.Location = new System.Drawing.Point(725, 553);
			this.MedDeathText.Name = "MedDeathText";
			this.MedDeathText.Size = new System.Drawing.Size(78, 16);
			this.MedDeathText.TabIndex = 17;
			this.MedDeathText.TextChanged += new System.EventHandler(this.MedDeathText_TextChanged);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)), true);
			this.label10.Location = new System.Drawing.Point(568, 10);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(90, 17);
			this.label10.TabIndex = 18;
			this.label10.Text = "Population:";
			// 
			// PopulationText
			// 
			this.PopulationText.BackColor = System.Drawing.SystemColors.Window;
			this.PopulationText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PopulationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.PopulationText.Location = new System.Drawing.Point(664, 10);
			this.PopulationText.Name = "PopulationText";
			this.PopulationText.Size = new System.Drawing.Size(77, 16);
			this.PopulationText.TabIndex = 19;
			// 
			// RealDeathText
			// 
			this.RealDeathText.BackColor = System.Drawing.SystemColors.Window;
			this.RealDeathText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RealDeathText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RealDeathText.Location = new System.Drawing.Point(140, 555);
			this.RealDeathText.Name = "RealDeathText";
			this.RealDeathText.Size = new System.Drawing.Size(80, 16);
			this.RealDeathText.TabIndex = 25;
			// 
			// RealInfectedText
			// 
			this.RealInfectedText.BackColor = System.Drawing.SystemColors.Window;
			this.RealInfectedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RealInfectedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RealInfectedText.Location = new System.Drawing.Point(140, 522);
			this.RealInfectedText.Name = "RealInfectedText";
			this.RealInfectedText.Size = new System.Drawing.Size(80, 16);
			this.RealInfectedText.TabIndex = 24;
			// 
			// RealHealthyText
			// 
			this.RealHealthyText.BackColor = System.Drawing.SystemColors.Window;
			this.RealHealthyText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RealHealthyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RealHealthyText.Location = new System.Drawing.Point(140, 486);
			this.RealHealthyText.Name = "RealHealthyText";
			this.RealHealthyText.Size = new System.Drawing.Size(80, 16);
			this.RealHealthyText.TabIndex = 23;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label11.Location = new System.Drawing.Point(14, 554);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(120, 17);
			this.label11.TabIndex = 22;
			this.label11.Text = "Count of death:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.label12.Location = new System.Drawing.Point(-1, 521);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(137, 17);
			this.label12.TabIndex = 21;
			this.label12.Text = "Count of infected:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label13.Location = new System.Drawing.Point(2, 485);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(132, 17);
			this.label13.TabIndex = 20;
			this.label13.Text = "Count of healthy:";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label14.Location = new System.Drawing.Point(281, 486);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(133, 17);
			this.label14.TabIndex = 26;
			this.label14.Text = "Count of doctors:";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label15.Location = new System.Drawing.Point(254, 521);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(160, 17);
			this.label15.TabIndex = 27;
			this.label15.Text = "Count of policemans:";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label16.Location = new System.Drawing.Point(278, 554);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(136, 17);
			this.label16.TabIndex = 28;
			this.label16.Text = "Count of soldiers:";
			// 
			// DoctorsCountText
			// 
			this.DoctorsCountText.BackColor = System.Drawing.SystemColors.Window;
			this.DoctorsCountText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DoctorsCountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DoctorsCountText.Location = new System.Drawing.Point(420, 485);
			this.DoctorsCountText.Name = "DoctorsCountText";
			this.DoctorsCountText.Size = new System.Drawing.Size(80, 16);
			this.DoctorsCountText.TabIndex = 29;
			// 
			// PolicemanCountText
			// 
			this.PolicemanCountText.BackColor = System.Drawing.SystemColors.Window;
			this.PolicemanCountText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PolicemanCountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.PolicemanCountText.Location = new System.Drawing.Point(420, 521);
			this.PolicemanCountText.Name = "PolicemanCountText";
			this.PolicemanCountText.Size = new System.Drawing.Size(80, 16);
			this.PolicemanCountText.TabIndex = 30;
			// 
			// SoldiersCountText
			// 
			this.SoldiersCountText.BackColor = System.Drawing.SystemColors.Window;
			this.SoldiersCountText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SoldiersCountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SoldiersCountText.Location = new System.Drawing.Point(420, 554);
			this.SoldiersCountText.Name = "SoldiersCountText";
			this.SoldiersCountText.Size = new System.Drawing.Size(80, 16);
			this.SoldiersCountText.TabIndex = 31;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label17.Location = new System.Drawing.Point(570, 574);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(151, 17);
			this.label17.TabIndex = 32;
			this.label17.Text = "Research progress:";
			// 
			// ResearchText
			// 
			this.ResearchText.BackColor = System.Drawing.SystemColors.Window;
			this.ResearchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ResearchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ResearchText.Location = new System.Drawing.Point(725, 575);
			this.ResearchText.Name = "ResearchText";
			this.ResearchText.Size = new System.Drawing.Size(78, 16);
			this.ResearchText.TabIndex = 33;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label18.Location = new System.Drawing.Point(645, 599);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(74, 17);
			this.label18.TabIndex = 34;
			this.label18.Text = "STATUS:";
			// 
			// StatusText
			// 
			this.StatusText.BackColor = System.Drawing.SystemColors.Window;
			this.StatusText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.StatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.StatusText.Location = new System.Drawing.Point(725, 600);
			this.StatusText.Name = "StatusText";
			this.StatusText.Size = new System.Drawing.Size(78, 16);
			this.StatusText.TabIndex = 35;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(965, 628);
			this.Controls.Add(this.StatusText);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.ResearchText);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.SoldiersCountText);
			this.Controls.Add(this.PolicemanCountText);
			this.Controls.Add(this.DoctorsCountText);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.RealDeathText);
			this.Controls.Add(this.RealInfectedText);
			this.Controls.Add(this.RealHealthyText);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.PopulationText);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.MedDeathText);
			this.Controls.Add(this.MedCriricalText);
			this.Controls.Add(this.MedInfectedText);
			this.Controls.Add(this.MedHealthyText);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.DayTimeText);
			this.Controls.Add(this.WetText);
			this.Controls.Add(this.TimeText);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Starter);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Visualisator";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button Starter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TimeText;
		private System.Windows.Forms.TextBox WetText;
		private System.Windows.Forms.TextBox DayTimeText;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox MedHealthyText;
		private System.Windows.Forms.TextBox MedInfectedText;
		private System.Windows.Forms.TextBox MedCriricalText;
		private System.Windows.Forms.TextBox MedDeathText;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox PopulationText;
		private System.Windows.Forms.TextBox RealDeathText;
		private System.Windows.Forms.TextBox RealInfectedText;
		private System.Windows.Forms.TextBox RealHealthyText;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox DoctorsCountText;
		private System.Windows.Forms.TextBox PolicemanCountText;
		private System.Windows.Forms.TextBox SoldiersCountText;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox ResearchText;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox StatusText;
	}
}

