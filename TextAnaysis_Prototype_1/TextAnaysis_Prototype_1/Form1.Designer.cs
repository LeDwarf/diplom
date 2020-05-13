namespace TextAnaysis_Prototype_1
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
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
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.buttonProcess = new System.Windows.Forms.Button();
			this.buttonSW = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(13, 13);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(545, 20);
			this.textBox1.TabIndex = 0;
			// 
			// buttonProcess
			// 
			this.buttonProcess.Location = new System.Drawing.Point(13, 51);
			this.buttonProcess.Name = "buttonProcess";
			this.buttonProcess.Size = new System.Drawing.Size(75, 23);
			this.buttonProcess.TabIndex = 1;
			this.buttonProcess.Text = "GO";
			this.buttonProcess.UseVisualStyleBackColor = true;
			this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
			// 
			// buttonSW
			// 
			this.buttonSW.Location = new System.Drawing.Point(13, 221);
			this.buttonSW.Name = "buttonSW";
			this.buttonSW.Size = new System.Drawing.Size(75, 23);
			this.buttonSW.TabIndex = 2;
			this.buttonSW.Text = "Стоп-слова";
			this.buttonSW.UseVisualStyleBackColor = true;
			this.buttonSW.Click += new System.EventHandler(this.buttonSW_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(570, 256);
			this.Controls.Add(this.buttonSW);
			this.Controls.Add(this.buttonProcess);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button buttonProcess;
		private System.Windows.Forms.Button buttonSW;
	}
}

