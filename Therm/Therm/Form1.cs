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
			Data.showInstructions();
		}
		public static Form1 ThisForm;

		private void GOButton_Click(object sender, EventArgs e)
		{
			Delta.delta(FormulaBox.Text);
		}

		public void write(string toCons)
		{
			Output.AppendText(toCons);
		}
		public void setH(double H) { DeltaH.Text = H.ToString(); }
		public void setS(double H) { DeltaS.Text = H.ToString(); }
		public void setG(double H) { DeltaG.Text = H.ToString(); }
		public void setGT(double H) { DeltaGT.Text = H.ToString(); }
		public void setTemp(double H) { Temp.Text = H.ToString(); }
		public void setK(double H) { EqConstBox.Text = H.ToString(); }
		public void setKunitAbove(string A) { KunitsAbove.Text = A; }
		public void setKunitBelow(string B) { KunitsBelow.Text = B; }

		public double getH()
		{
			while (true)
			{
				try
				{
					return double.Parse(DeltaH.Text);
				}
				catch (Exception)
				{
					write("DeltaH is not a number. Please specify\n");
					return 0;
				}
			}
		}
		public double getS()
		{
			while (true)
			{
				try
				{
					return double.Parse(DeltaS.Text);
				}
				catch (Exception)
				{
					write("DeltaS is not a number. Please specify\n");
					return 0;
				}
			}
		}
		public double getG()
		{
			while (true)
			{
				try
				{
					return double.Parse(DeltaG.Text);
				}
				catch (Exception)
				{
					write("DeltaG is not a number. Please specify\n");
					return 0;
				}
			}
		}
		public double getGT()
		{
			while (true)
			{
				try
				{
					return double.Parse(DeltaGT.Text);
				}
				catch (Exception)
				{
					write("DeltaGT is not a number. Please specify\n");
					return 0;
				}
			}
		}
		public double getTemp()
		{
			while (true)
			{
				try
				{
					return double.Parse(Temp.Text);
				}
				catch (Exception)
				{
					write("Temperature is not a number. Please specify\n");
					return 0;
				}
			}
		}

		public double getR()
		{
			try
			{
				string num = "";
				string R = GasConstant.Text;
				int index = 0;
				while (Sort.isNum(R[index]) || R[index].Equals(',') || R[index].Equals('.'))
				{
					num += R[index];
					index++;
				}
				return double.Parse(num.Replace('.', ','));
					
			}
			catch
			{
				Data.WriteLine("Please specify gas Constant");
				return 0;
			}
		}

		private void Temp_TextChanged(object sender, EventArgs e)
		{
			string check = Temp.Text.ToLower();
			
			if (check.Contains("c"))
			{
				check = check.Replace(" ", "").Replace("c", "");
				Temp.Text = (double.Parse(check) + 273).ToString();
			}
		}

		private void FormulaBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode.Equals(Keys.Enter))
			{
				GOButton_Click(sender, e);
			}
		}

		private void Requals_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
