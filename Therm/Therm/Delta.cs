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
					try
					{
						Data.WriteLine("Unable to find Values.data. Creating new file");
						//Creates the file, and closes it again. Neccesary because the WriteAllText method opens it again.
						System.IO.File.CreateText(@"..\Values.data").Close();
						using (WebClient client = new WebClient())
						{
							System.IO.File.WriteAllText(@"..\Values.data", client.DownloadString("http://bilbo.chm.uri.edu/CHM112/tables/thermtable.htm"));
						}
						s = System.IO.File.ReadAllLines(@"..\Values.data");
						foreach (string textLine in s)
						{
							Data.WriteLine(textLine);
						}
						Data.WriteLine("Got text online");
						Data.WriteLine("Created file sucessfully");
						break;
					}
					catch
					{
						Data.WriteLine("Unable to get data from web.");
						s = new string[1];
						s[0] = "";
						break;
					}
				}
			}
			

			//resets everything
			index = 0;
			temp = null;
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
				//creates the Element objects as well as giving them a searchable string defined by said input
				//Sort.createSearch(input);
				/**
			* Example code for debugging. Burning of methane
			**/
				

				elmnts.Add(new Element());
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
				elmnts[stuff].mult = 1;



				/***elmnts.Add(new Element());
				elmnts[stuff].search = "<p>";
				while (index < input.Length)
				{
					if (Sort.isNum(input[index]))
					{
						elmnts[stuff].mult = int.Parse(input.Substring(index, 1));
						index++;
						Data.WriteLine("Got number " + elmnts[stuff].mult);
					}
					else if (input[index].Equals(' '))
					{
						index++;
					}
					else if (input[index].Equals(':'))
					{
						if (input[index + 1].Equals('+'))
						{
							index++;
							elmnts[stuff].search += "<sup>" + input.Substring(index, 1) + "</sup>";
							index += 1;
						}
						else if (input[index + 1].Equals('-'))
						{
							index++;
							elmnts[stuff].search += "<sup>&#150;</sup>";
							index += 1;
						}
						else
						{
							index++;
							elmnts[stuff].search += "<sup>" + input.Substring(index, 2) + "</sup>";
							index += 2;
							elmnts[stuff].search = elmnts[stuff].search.Replace("-", "&#150;");
						}

					}
					else if (input[index].Equals('_'))
					{
						index++;
						elmnts[stuff].search += "<sub>" + input.Substring(index, 1) + "</sub>";
						index++;
					}
					else if (input[index].Equals('+'))
					{
						elmnts.Add(new Element());
						stuff++;
						index++;
						elmnts[stuff].search = "<p>";
					}
					else if (input[index].Equals('('))
					{
						if (input.Substring(index + 1, 1).Equals("s") ||
							input.Substring(index + 1, 1).Equals("l") ||
							input.Substring(index + 1, 1).Equals("g"))
						{
							if (input[index + 2].Equals(','))
							{
								elmnts[stuff].search += "(<i>" + input.Substring(index + 1, 1) + "</i>, <i>";
								index += 3;
								while (!input[index].Equals(')'))
								{
									if (!input[index].Equals(' '))
									{
										elmnts[stuff].search += input[index];
									}
									index++;
								}
								elmnts[stuff].search += "</i>)";
								index++;
							}
							else
							{
								elmnts[stuff].search += "(<i>" + input.Substring(index + 1, 1) + "</i>)";
								index += 3;
							}
						}
						else if (input.Substring(index + 1, 2).Equals("aq"))
						{
							elmnts[stuff].search += "(<i>" + input.Substring(index + 1, 2) + "</i>)";
							index += 4;
						}
					}
					else if (input[index].Equals('-') && input[index + 1].Equals('>'))
					{
						elmnts.Add(new Element());
						stuff++;
						index += 2;
						arrowAt = stuff;
						elmnts[stuff].search = "<p>";
					}
					else
					{
						elmnts[stuff].search += input[index];
						index++;
					}

					Data.WriteLine("Search for " + elmnts[stuff].search);
				}*/



				//Searches the data file and stores the relavent data in the Element objects.
				foreach (Element element in elmnts)
				{
					index = 0;
					while (index < s.Length)
					{
						index++;
						if (s[index].Contains(element.search))
						{
							if (s[index + 1].Contains(element.state))
							{
								break;
							}
						}
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
					index++;
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


				Equlibrium.calcK(elmnts);
			}
		}
	}
}
