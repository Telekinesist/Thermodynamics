namespace Therm
{
	partial class Help
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
			this.HelpImagePicBox = new System.Windows.Forms.PictureBox();
			this.Instructions = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.HelpImagePicBox)).BeginInit();
			this.SuspendLayout();
			// 
			// HelpImagePicBox
			// 
			this.HelpImagePicBox.Image = global::Therm.Properties.Resources.HelpImage;
			this.HelpImagePicBox.Location = new System.Drawing.Point(13, 13);
			this.HelpImagePicBox.Name = "HelpImagePicBox";
			this.HelpImagePicBox.Size = new System.Drawing.Size(940, 540);
			this.HelpImagePicBox.TabIndex = 0;
			this.HelpImagePicBox.TabStop = false;
			// 
			// Instructions
			// 
			this.Instructions.Font = new System.Drawing.Font("Georgia", 11F);
			this.Instructions.Location = new System.Drawing.Point(13, 560);
			this.Instructions.Name = "Instructions";
			this.Instructions.ReadOnly = true;
			this.Instructions.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.Instructions.Size = new System.Drawing.Size(940, 869);
			this.Instructions.TabIndex = 1;
			this.Instructions.Text = resources.GetString("Instructions.Text");
			// 
			// Help
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(970, 740);
			this.Controls.Add(this.Instructions);
			this.Controls.Add(this.HelpImagePicBox);
			this.MaximumSize = new System.Drawing.Size(986, 9999);
			this.MinimumSize = new System.Drawing.Size(986, 39);
			this.Name = "Help";
			this.Text = "Help";
			this.Load += new System.EventHandler(this.Help_Load);
			((System.ComponentModel.ISupportInitialize)(this.HelpImagePicBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox HelpImagePicBox;
		private System.Windows.Forms.RichTextBox Instructions;
	}
}