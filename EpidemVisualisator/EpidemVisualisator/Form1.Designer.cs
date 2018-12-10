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
			this.label1.Location = new System.Drawing.Point(7, -1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(278, 29);
			this.label1.TabIndex = 2;
			this.label1.Text = "Novomoskovsk region:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(321, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Temperature:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)), true);
			this.label3.Location = new System.Drawing.Point(503, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Wet:";
			// 
			// TimeText
			// 
			this.TimeText.BackColor = System.Drawing.SystemColors.Control;
			this.TimeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TimeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TimeText.Location = new System.Drawing.Point(433, 11);
			this.TimeText.Name = "TimeText";
			this.TimeText.Size = new System.Drawing.Size(58, 16);
			this.TimeText.TabIndex = 5;
			// 
			// WetText
			// 
			this.WetText.BackColor = System.Drawing.SystemColors.Control;
			this.WetText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.WetText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.WetText.Location = new System.Drawing.Point(550, 10);
			this.WetText.Name = "WetText";
			this.WetText.Size = new System.Drawing.Size(58, 16);
			this.WetText.TabIndex = 6;
			// 
			// DayTimeText
			// 
			this.DayTimeText.BackColor = System.Drawing.SystemColors.Control;
			this.DayTimeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DayTimeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DayTimeText.Location = new System.Drawing.Point(713, 12);
			this.DayTimeText.Name = "DayTimeText";
			this.DayTimeText.Size = new System.Drawing.Size(190, 16);
			this.DayTimeText.TabIndex = 7;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(965, 628);
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
	}
}

