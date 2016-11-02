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
			this.DeltaS = new System.Windows.Forms.TextBox();
			this.DeltaG = new System.Windows.Forms.TextBox();
			this.DeltaGT = new System.Windows.Forms.TextBox();
			this.Temp = new System.Windows.Forms.TextBox();
			this.FormulaBox = new System.Windows.Forms.TextBox();
			this.GOButton = new System.Windows.Forms.Button();
			this.Output = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// DeltaName
			// 
			this.DeltaName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeltaName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DeltaName.Location = new System.Drawing.Point(940, 12);
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
			this.Units.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Units.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Units.Location = new System.Drawing.Point(1044, 12);
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
			this.DeltaH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeltaH.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DeltaH.Location = new System.Drawing.Point(987, 13);
			this.DeltaH.Margin = new System.Windows.Forms.Padding(0);
			this.DeltaH.Name = "DeltaH";
			this.DeltaH.Size = new System.Drawing.Size(54, 13);
			this.DeltaH.TabIndex = 3;
			this.DeltaH.Text = "Undefined";
			// 
			// DeltaS
			// 
			this.DeltaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeltaS.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DeltaS.Location = new System.Drawing.Point(987, 26);
			this.DeltaS.Margin = new System.Windows.Forms.Padding(0);
			this.DeltaS.Name = "DeltaS";
			this.DeltaS.Size = new System.Drawing.Size(54, 13);
			this.DeltaS.TabIndex = 4;
			this.DeltaS.Text = "Undefined";
			// 
			// DeltaG
			// 
			this.DeltaG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeltaG.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DeltaG.Location = new System.Drawing.Point(987, 39);
			this.DeltaG.Margin = new System.Windows.Forms.Padding(0);
			this.DeltaG.Name = "DeltaG";
			this.DeltaG.Size = new System.Drawing.Size(54, 13);
			this.DeltaG.TabIndex = 5;
			this.DeltaG.Text = "Undefined";
			// 
			// DeltaGT
			// 
			this.DeltaGT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeltaGT.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DeltaGT.Location = new System.Drawing.Point(987, 52);
			this.DeltaGT.Margin = new System.Windows.Forms.Padding(0);
			this.DeltaGT.Name = "DeltaGT";
			this.DeltaGT.Size = new System.Drawing.Size(54, 13);
			this.DeltaGT.TabIndex = 6;
			this.DeltaGT.Text = "Undefined";
			// 
			// Temp
			// 
			this.Temp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Temp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Temp.Location = new System.Drawing.Point(987, 65);
			this.Temp.Margin = new System.Windows.Forms.Padding(0);
			this.Temp.Name = "Temp";
			this.Temp.Size = new System.Drawing.Size(54, 13);
			this.Temp.TabIndex = 7;
			this.Temp.Text = "Undefined";
			// 
			// FormulaBox
			// 
			this.FormulaBox.AcceptsReturn = true;
			this.FormulaBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FormulaBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.FormulaBox.Location = new System.Drawing.Point(12, 12);
			this.FormulaBox.Name = "FormulaBox";
			this.FormulaBox.Size = new System.Drawing.Size(841, 30);
			this.FormulaBox.TabIndex = 8;
			this.FormulaBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormulaBox_KeyPress);
			// 
			// GOButton
			// 
			this.GOButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.GOButton.Location = new System.Drawing.Point(859, 12);
			this.GOButton.Name = "GOButton";
			this.GOButton.Size = new System.Drawing.Size(75, 23);
			this.GOButton.TabIndex = 9;
			this.GOButton.Text = "GO";
			this.GOButton.UseVisualStyleBackColor = true;
			this.GOButton.Click += new System.EventHandler(this.GOButton_Click);
			// 
			// Output
			// 
			this.Output.AcceptsReturn = true;
			this.Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Output.Location = new System.Drawing.Point(12, 86);
			this.Output.Multiline = true;
			this.Output.Name = "Output";
			this.Output.ReadOnly = true;
			this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.Output.Size = new System.Drawing.Size(1086, 343);
			this.Output.TabIndex = 10;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1110, 441);
			this.Controls.Add(this.Output);
			this.Controls.Add(this.GOButton);
			this.Controls.Add(this.FormulaBox);
			this.Controls.Add(this.Temp);
			this.Controls.Add(this.DeltaGT);
			this.Controls.Add(this.DeltaG);
			this.Controls.Add(this.DeltaS);
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
		private System.Windows.Forms.TextBox DeltaS;
		private System.Windows.Forms.TextBox DeltaG;
		private System.Windows.Forms.TextBox DeltaGT;
		private System.Windows.Forms.TextBox Temp;
		private System.Windows.Forms.TextBox FormulaBox;
		private System.Windows.Forms.Button GOButton;
		public System.Windows.Forms.TextBox Output;
	}
}

