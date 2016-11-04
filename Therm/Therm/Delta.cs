using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Therm
{
	static class Delta
	{

		public static void delta(string input)
		{
			//The search translater crashes weirdly if there isn't a character after the last molecule, such as the phase
			input = input.Replace("\n", "").Replace("\t", "") + " ";
			string[] s;
			string temp;
			List<Element> elmnts = new List<Element>();
			double deltH, deltG, deltS, deltGT, prodSum = 0, reacSum = 0;
			int stuff = 0, index = 0, arrowAt = 0;
			string line = "=================================================================================================================";

			//Loads data
			while (true)
			{
				try
				{
					s = System.IO.File.ReadAllLines(@"..\Values.data");
					break;
				}
				catch
				{
					Data.WriteLine("Could not find Values.data");
					Data.WriteLine("Have you moved the program out of its originating folder?");
				}
			}
			

			//resets everything
			index = 0;
			temp = "";
			deltG = 0;
			deltH = 0;
			deltS = 0;
			elmnts.Clear();
			arrowAt = 0;
			index = 0;
			stuff = 0;
			prodSum = 0;
			reacSum = 0;

			//Burning of methane equation for quick testing. It lacks the matter state, but that is not nessesary in this equation because gas is at the top of the list 
			//CH_4 + 2O_2 -> 2H_2O + CO_2


			if (input.Length < 1 || input.Length.Equals(1))
			{
				Data.WriteLine("That can't be right");
			}
			else
			{
				if (input.ToLower().Equals("meth"))
				{
					input = "CH_4 + 2O_2-> 2H_2O + CO_2";
				}
				//creates the Element objects as well as giving them a searchable string defined by said input
				/**
			* Example code for debugging. Burning of methane
			**/
				

				/**elmnts.Add(new Element());
				elmnts[stuff].search = "<TD>CH<sub>4</sub></TD>";
				elmnts[stuff].state = "(g";
				elmnts[stuff].mult = 1;

				elmnts.Add(new Element());
				stuff++;
				elmnts[stuff].search = "<TD>O<sub>2</sub></TD>";
				elmnts[stuff].state = "(g";
				elmnts[stuff].mult = 2;

				arrowAt = 2;

				elmnts.Add(new Element());
				stuff++;
				elmnts[stuff].search = "<TD>H<sub>2</sub>O</TD>";
				elmnts[stuff].state = "(g";
				elmnts[stuff].mult = 2;

				elmnts.Add(new Element());
				stuff++;
				elmnts[stuff].search = "<TD>CO<sub>2</sub></TD>";
				elmnts[stuff].state = "(g";
				elmnts[stuff].mult = 1;*/



				elmnts.Add(new Element());
				elmnts[stuff].search = "<TD>";
				while (index < input.Length)
				{
					if (Sort.isNum(input[index]))
					{
						while (Sort.isNum(input[index]))
						{
							temp += input[index];
							index++;
						}

						elmnts[stuff].mult = int.Parse(temp);
						temp = "";
						Data.WriteLine("Got number " + elmnts[stuff].mult);
					}
					else if (input[index].Equals(' '))
					{
						index++;
					}
					else if (input[index].Equals(':'))
					{
						index++;
						while (input[index].Equals('+') || input[index].Equals('-') || Sort.isNum(input[index]))
						{
							temp += input[index];
							index++;
						}
						elmnts[stuff].search += "<sup>" + temp + "</sup>";
						temp = "";

					}
					else if (input[index].Equals('_'))
					{
						index++;
						while (Sort.isNum(input[index]))
						{
							temp += input[index];
							index++;
						}
						elmnts[stuff].search += "<sub>" + temp + "</sub>";
						temp = "";
					}
					else if (input[index].Equals('('))
					{
						index++;
						if (input[index].Equals('g') || input[index].Equals('s') || input[index].Equals('l') || input.Substring(index, 2).Equals("aq"))
						{
							temp = "<TD>(";
							while (!input[index].Equals(')'))
							{
								temp += input[index];
								index++;
							}
							elmnts[stuff].state = temp;
							temp = "";
							index++;
						}
						else
						{
							elmnts[stuff].search += '(';
						}
					}
					else if (input[index].Equals('+'))
					{
						elmnts.Add(new Element());
						stuff++;
						index++;
						elmnts[stuff].search = "<TD>";
					}
					else if (index+2 < input.Length && input.Substring(index, 2).Equals("->"))
					{
						elmnts.Add(new Element());
						stuff++;
						index += 2;
						arrowAt = stuff;
						elmnts[stuff].search = "<TD>";
					}
					else
					{
						elmnts[stuff].search += input[index];
						index++;
					}

					Data.WriteLine("Search for " + elmnts[stuff].search + " " + elmnts[stuff].state);
				}
				//Searches the data file and stores the relavent data in the Element objects.
				foreach (Element element in elmnts)
				{
					/*int q = 0;
					while (true)
					{
						temp = "";
						index = 0;
						while (index < s.Length)
						{
							index++;
							if (s[index].Contains(element.search))
							{
								if (s[index + 1].Contains(element.state))
								{
									goto exit;
								}
								else
								{
									switch (q)
									{
										case 0:
											element.state = "(g";
											break;
										case 1:
											element.state = "(l";
											break;
										case 2:
											element.state = "(aq";
											break;
										case 3:
											element.state = "(l";
											break;
										default:
											Data.WriteLine("ERROR: element does not exist. Check your input, or if the molecule is listed in the datasheet");
											element.notFound = true;
											goto exit;
									}
									q++;
								}
							}
						}*/
					index = 0;
					while (index < s.Length && !s[index].Contains(element.search))
					{
						index++;
					}
					if (index.Equals(s.Length))
					{
						Data.WriteLine("ERROR: Element does not exist. Check your input, or if the molecule is listed in the datasheet");
						element.notFound = true;
						break;
					}
					//Displays the found result, and skips two lines (the molecule and state)
					Data.WriteLine(s[index]);
					Data.WriteLine(s[index + 1]);
					index += 2;

					//Gets the molar enthalpy
					temp = s[index];
					temp = temp.Replace("\t", "").Replace("<TD>", "").Replace("</TD>", "").Replace(".", ",");
					element.H = double.Parse(temp);

					Data.WriteLine("H=" + element.H);
					index++;


					//Gets the molar entropy
					temp = s[index];
					temp = temp.Replace("\t", "").Replace("<TD>", "").Replace("</TD>", "").Replace(".", ",");
					element.S = double.Parse(temp);

					Data.WriteLine("S=" + element.S);
					index++;


					//Gets the molar gibbs energy
					temp = s[index];
					temp = temp.Replace("\t", "").Replace("<TD>", "").Replace("</TD>", "").Replace(".", ",");
					element.G = double.Parse(temp);

					Data.WriteLine("H=" + element.G);
					
				}


				//Calculated the molekular change of H, G and S
				//Sort.calcDelta();
				reacSum = prodSum = 0;
				for (int q = elmnts.Count - 1; q >= 0; q--)
				{
					Data.WriteLine("Element " + q + " " + elmnts[q].H + " " + elmnts[q].G + " " + elmnts[q].S);
					if (q < arrowAt)
					{
						reacSum += elmnts[q].H * elmnts[q].mult;
						Data.WriteLine("r" + reacSum);
					}
					else
					{
						prodSum += elmnts[q].H * elmnts[q].mult;
						Data.WriteLine("p" + prodSum);
					}
				}
				deltH = prodSum - reacSum;

				reacSum = prodSum = 0;
				for (int q = elmnts.Count - 1; q >= 0; q--)
				{
					if (q < arrowAt)
					{
						reacSum += elmnts[q].G * elmnts[q].mult;
					}
					else
					{
						prodSum += elmnts[q].G * elmnts[q].mult;
					}
				}
				deltG = prodSum - reacSum;

				reacSum = prodSum = 0;
				for (int q = elmnts.Count - 1; q >= 0; q--)
				{
					if (q < arrowAt)
					{
						reacSum += elmnts[q].S * elmnts[q].mult;
					}
					else
					{
						prodSum += elmnts[q].S * elmnts[q].mult;
					}
				}
				deltS = prodSum - reacSum;



				//Δ
				Data.WriteLine(line);
				string[] names = input.Replace(":+", ":p").Replace(":-", ":n").Replace("-", "").Replace(" ", "").Split('+', '>');
				Data.Write("Name:\t");
				foreach (string nam in names)
				{
					if (nam.Length > 6)
					{
						Data.Write("|" + nam + "\t");
					}
					else
					{
						Data.Write("|" + nam + "\t\t");
					}

				}
				Data.WriteLine();
				Data.Write("H:\t");
				foreach (Element element in elmnts)
				{
					if (element.notFound)
					{
						Data.Write("Missing!");
					}
					else if (element.G.ToString().Length > 8)
					{
						Data.Write("|" + element.H + "\t");
					}
					else
					{
						Data.Write("|" + element.H + "\t\t");
					}
				}
				Data.WriteLine();
				Data.Write("G:\t");
				foreach (Element element in elmnts)
				{
					if (element.notFound)
					{
						Data.Write("Missing!");
					}
					else if (element.G.ToString().Length > 8)
					{
						Data.Write("|" + element.G + "\t");
					}
					else
					{
						Data.Write("|" + element.G + "\t\t");
					}
				}
				Data.WriteLine();
				Data.Write("S:\t");
				foreach (Element element in elmnts)
				{
					if (element.notFound)
					{
						Data.Write("Missing!");
					}
					else if (element.G.ToString().Length > 8)
					{
						Data.Write("|" + element.S + "\t");
					}
					else
					{
						Data.Write("|" + element.S + "\t\t");
					}
				}
				
				//Devided by thousand because the unit needs to be kJ, but is J.
				deltGT = (deltH - (Form1.ThisForm.getTemp() * deltS / 1000));

				Data.WriteLine();
				Data.WriteLine(line);
				Data.WriteLine("ΔHᴼ=" + deltH + "kJ/Mol");
				Data.WriteLine("ΔGᴼ=" + deltG + "kJ/Mol");
				Data.WriteLine("ΔG =" + deltGT + "kJ/Mol");
				Data.WriteLine("ΔSᴼ=" + deltS + "J/(Mol*K)");
				Data.WriteLine(line);

				Form1.ThisForm.setH(deltH);
				Form1.ThisForm.setG(deltG);
				Form1.ThisForm.setS(deltS);
				Form1.ThisForm.setGT(deltGT);


				Equlibrium.calcK(elmnts, arrowAt);
			}
		}
	}
}
