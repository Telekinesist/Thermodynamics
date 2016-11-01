namespace Therm
{
	partial class Form1
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
			this.DeltaName = new System.Windows.Forms.TextBox();
			this.Units = new System.Windows.Forms.TextBox();
			this.DeltaH = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// DeltaName
			// 
			this.DeltaName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DeltaName.Location = new System.Drawing.Point(677, 12);
			this.DeltaName.Multiline = true;
			this.DeltaName.Name = "DeltaName";
			this.DeltaName.ReadOnly = true;
			this.DeltaName.Size = new System.Drawing.Size(45, 68);
			this.DeltaName.TabIndex = 0;
			this.DeltaName.Text = "ΔHᴼ  =\r\nΔSᴼ  =\r\nΔGᴼ  =\r\nΔG  =\r\nT  =";
			this.DeltaName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Units
			// 
			this.Units.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Units.Location = new System.Drawing.Point(781, 12);
			this.Units.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.Units.Multiline = true;
			this.Units.Name = "Units";
			this.Units.ReadOnly = true;
			this.Units.Size = new System.Drawing.Size(54, 68);
			this.Units.TabIndex = 2;
			this.Units.Text = "kJ/mol\r\nJ/(mol*K)\r\nkJ/mol\r\nkJ/mol\r\n°K";
			// 
			// DeltaH
			// 
			this.DeltaH.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DeltaH.Location = new System.Drawing.Point(724, 13);
			this.DeltaH.Margin = new System.Windows.Forms.Padding(0);
			this.DeltaH.Name = "DeltaH";
			this.DeltaH.ReadOnly = true;
			this.DeltaH.Size = new System.Drawing.Size(54, 13);
			this.DeltaH.TabIndex = 3;
			this.DeltaH.Text = "Undefined";
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Location = new System.Drawing.Point(724, 26);
			this.textBox1.Margin = new System.Windows.Forms.Padding(0);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(54, 13);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "Undefined";
			// 
			// textBox3
			// 
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox3.Location = new System.Drawing.Point(724, 39);
			this.textBox3.Margin = new System.Windows.Forms.Padding(0);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(54, 13);
			this.textBox3.TabIndex = 5;
			this.textBox3.Text = "Undefined";
			// 
			// textBox4
			// 
			this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox4.Location = new System.Drawing.Point(724, 52);
			this.textBox4.Margin = new System.Windows.Forms.Padding(0);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(54, 13);
			this.textBox4.TabIndex = 6;
			this.textBox4.Text = "Undefined";
			// 
			// textBox5
			// 
			this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox5.Location = new System.Drawing.Point(724, 65);
			this.textBox5.Margin = new System.Windows.Forms.Padding(0);
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(54, 13);
			this.textBox5.TabIndex = 7;
			this.textBox5.Text = "Undefined";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(847, 358);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.DeltaH);
			this.Controls.Add(this.Units);
			this.Controls.Add(this.DeltaName);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox DeltaName;
		private System.Windows.Forms.TextBox Units;
		private System.Windows.Forms.TextBox DeltaH;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
	}
}

