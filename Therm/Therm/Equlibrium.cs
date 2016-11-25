using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Therm
{
	static class Equlibrium
	{
		public static void calcK(List<Element> Elelemts, int arrowAt)
		{
			int MA = 0, MB = 0, PA = 0, PB = 0, LA = 0, LB = 0;
			string A = "", B = "", temp = "";


			Main Form = Main.ThisForm;
			//N_2(g) + 3H_2(g) -> 2NH_3(g)
			//SO_2Cl_2(g) -> SO_2(g) + Cl_2(g)
			//2CH_3OH(g) -> CH_3OCH_3(g) + H_2O(g)
			double K = Math.Pow(Math.E, -((Form.getG()*1000)/(Form.getR()*Form.getTemp())));
			//K = -((Form.getG() * 1000) / (Form.getR() * Form.getTemp()));
			Form.setK(K.ToString().Replace("+", "").Replace("E", "*10^"));

			for (int i = 0; i < Elelemts.Count; i++)
			{
				if (i <= arrowAt - 1)
				{
					if (Elelemts[i].state.Contains(":aq:"))
					{
						MB += int.Parse(Math.Round(Elelemts[i].mult).ToString());
					}
					else if (Elelemts[i].state.Contains(":g:"))
					{
						PB += int.Parse(Math.Round(Elelemts[i].mult).ToString());
					}
					else if (Elelemts[i].state.Contains(":l:"))
					{
						LB += int.Parse(Math.Round(Elelemts[i].mult).ToString());
					}
				}
				else
				{
					if (Elelemts[i].state.Contains(":aq:"))
					{
						MA += int.Parse(Math.Round(Elelemts[i].mult).ToString());
					}
					else if (Elelemts[i].state.Contains(":g:"))
					{
						PA += int.Parse(Math.Round(Elelemts[i].mult).ToString());
					}
					else if (Elelemts[i].state.Contains(":l:"))
					{
						LA += int.Parse(Math.Round(Elelemts[i].mult).ToString());
					}
				}
			}
			


			//Removes units devided by themselfs
			if (PA >= PB)
			{
				PA -= PB;
				PB = 0;
			}
			else
			{
				PB -= PA;
				PA = 0;
			}
			if (LA >= LB)
			{
				LA -= LB;
				LB = 0;
			}
			else
			{
				LB -= LA;
				LA = 0;
			}
			if (MA >= MB)
			{
				MA -= MB;
				MB = 0;
			}
			else
			{
				MB -= MA;
				MA = 0;
			}


			//Numerator units
			if (PA.Equals(1))
			{
				A += "bar ";
			}
			else if (PA > 1)
			{
				A += "bar^" + PA + " ";
			}
			if (LA.Equals(1))
			{
				A += "L ";
			}
			else if (LA > 1)
			{
				A += "L^" + LA + " ";
			}
			if (MA.Equals(1))
			{
				A += "M ";
			}
			else if (MA > 1)
			{
				A += "M^" + MA + " ";
			}

			//Denominator units
			if (PB.Equals(1))
			{
				B += "bar ";
			}
			else if (PB > 1)
			{
				B += "bar^" + PB + " ";
			}
			if (LB.Equals(1))
			{
				B += "L ";
			}
			else if (LB > 1)
			{
				B += "L^" + LB + " ";
			}
			if (MB.Equals(1))
			{
				B += "M ";
			}
			else if (MB > 1)
			{
				B += "M^" + MB + " ";
			}

			//If the reaction arrow is pointing left
			if (Delta.reverse)
			{
				temp = A;
				A = B;
				B = temp;
			}


			//Displays a one in the numerator if the numerator is otherwise empty while the denominator is not
			//Also checks if the string is empty, and turns it into a space. Used to be replaced by " * " and will prevent crash when removing the last three letters
			if (A.Length < 1)
			{
				if (B.Length > 0)
				{
					A = "1 ";
				}
				else
				{
					A = "Unitless ";
				}

			}
			if (B.Length < 1)
			{
				B = " ";
			}

			//Print values
			A = A.Replace(" ", " * ");
			B = B.Replace(" ", " * ");
			A = A.Substring(0, A.Length - 3);
			B = B.Substring(0, B.Length - 3);

			Form.setKunitAbove(A);
			Form.setKunitBelow(B);
		}
	}
}
