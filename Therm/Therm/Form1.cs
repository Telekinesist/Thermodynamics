using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Therm
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			ThisForm = this;
		}
		public static Form1 ThisForm;

		private void GOButton_Click(object sender, EventArgs e)
		{
			Delta.delta(FormulaBox.Text);
		}

		private void FormulaBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.Equals(Keys.Enter))
			{
				GOButton_Click(sender, e);
			}
		}

		public void write(string toCons)
		{
			Output.AppendText(toCons);
		}
	}
}
