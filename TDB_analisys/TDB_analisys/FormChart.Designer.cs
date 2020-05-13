namespace TDB_analisys
{
	partial class FormChart
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.buttonFill = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.labelCount = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.labelTime = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(3, 3);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(804, 393);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.chart1.Visible = false;
			// 
			// buttonFill
			// 
			this.buttonFill.Location = new System.Drawing.Point(12, 12);
			this.buttonFill.Name = "buttonFill";
			this.buttonFill.Size = new System.Drawing.Size(75, 23);
			this.buttonFill.TabIndex = 1;
			this.buttonFill.Text = "Заполнить";
			this.buttonFill.UseVisualStyleBackColor = true;
			this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(344, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Всего задач:";
			// 
			// labelCount
			// 
			this.labelCount.AutoSize = true;
			this.labelCount.Location = new System.Drawing.Point(422, 23);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(13, 13);
			this.labelCount.TabIndex = 3;
			this.labelCount.Text = "0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(484, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(214, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Среднее время выполнения задачи, час:";
			this.label3.Visible = false;
			// 
			// labelTime
			// 
			this.labelTime.AutoSize = true;
			this.labelTime.Location = new System.Drawing.Point(704, 23);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(13, 13);
			this.labelTime.TabIndex = 5;
			this.labelTime.Text = "0";
			this.labelTime.Visible = false;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Запланировано - часы",
            "Запланировано - дни",
            "Выполнено - часы"});
			this.comboBox1.Location = new System.Drawing.Point(94, 13);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(140, 21);
			this.comboBox1.TabIndex = 6;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.chart1);
			this.panel1.Location = new System.Drawing.Point(12, 50);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(810, 399);
			this.panel1.TabIndex = 7;
			// 
			// FormChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(834, 461);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.labelTime);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.labelCount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonFill);
			this.Name = "FormChart";
			this.Text = "Аналитика";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Button buttonFill;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelCount;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Panel panel1;
	}
}