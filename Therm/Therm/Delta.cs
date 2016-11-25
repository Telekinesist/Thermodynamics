using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Therm
{
	static class Delta
	{
		public static bool elmntsIsNotEmpty = false;

		static string[] s;
		static string temp;
		public static List<Element> elmnts = new List<Element>();
		static double deltH, deltG, deltS, deltGT, prodSum = 0, reacSum = 0;
		public static int stuff = 0, index = 0, arrowAt = 0;
		static string line = "=================================================================================================================";
		static string input = "";
		public static bool reverse = false;

		//It for some reason rediciously complicated to read form an embedded file, but this should return all lines in a file
		public static string[] readAllLines(string path)
		{
			Assembly asembl = Assembly.GetExecutingAssembly();
			using (Stream strem = asembl.GetManifestResourceStream(path))
			{
				using (StreamReader reader = new StreamReader(strem))
				{
					char[] nl = new char[1];
					nl[0] = '\n';
					return reader.ReadToEnd().Split(nl);
				}
			}
		}


		public static void delta(string formula)
		{
			//The search translater crashes weirdly if there isn't a character after the last molecule, such as the phase
			input = formula.Replace("\n", "").Replace("\t", "").Replace(".", ",") + " ";

			//Loads data
			while (true)
			{
				try
				{
					s = readAllLines("Therm.Values.data");

					break;
				}
				catch
				{
					Data.WriteLine("Could not find standard thermodynamic values");
					Data.WriteLine("Please contact the developer");
					return;
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
			reverse = false;

			//Burning of methane equation for quick testing. It lacks the matter state, but that is not nessesary in this equation because gas is at the top of the list 
			//CH_4 + 2O_2 -> 2H_2O + CO_2


			if (input.Length < 1 || input.Length.Equals(1))
			{
				Data.WriteLine("That can't be right");
			}
			else
			{
				if (input.ToLower().Equals("help"))
				{
					Data.showInstructions();
				}
				else if (input.ToLower().Replace(" ", "").Contains("wat"))
				{
					Data.WriteLine(input);
					input = "2H2(g) + O2(g)-> 2H2O(g)";
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
				while (index < input.Length)
				{
					if (input[index].Equals('('))
					{
						if (index + 3 < input.Length && input.Substring(index, 3).Equals("(s)") || input.Substring(index, 3).Equals("(l)") || input.Substring(index, 3).Equals("(g)"))
						{
							elmnts[stuff].state = input.Substring(index + 1, 1);
							index += 3;
						}
						else if (index + 4 < input.Length && input.Substring(index, 4).Equals("(aq)"))
						{
							elmnts[stuff].state = input.Substring(index + 1, 2);
							index += 4;
						}
						else
						{
							elmnts[stuff].search += input[index];
							index++;
						}
					}
					else if (index + 3 < input.Length && input.Substring(index, 3).Equals(" + "))
					{
						elmnts[stuff].search.Replace(" ", "");
						elmnts.Add(new Element());
						stuff++;
						index += 3;
					}
					else if (index + 1 < input.Length && input.Substring(index, 2).Equals("->"))
					{
						elmnts[stuff].search.Replace(" ", "");
						elmnts.Add(new Element());
						stuff++;
						index += 2;
						arrowAt = stuff;
					}
					else if (index + 1 < input.Length && input.Substring(index, 2).Equals("<-"))
					{
						elmnts[stuff].search.Replace(" ", "");
						elmnts.Add(new Element());
						stuff++;
						index += 2;
						reverse = true;
						arrowAt = stuff;
					}
					else if (input[index].Equals(' '))
					{
						index++;
					}
					else
					{
						elmnts[stuff].search += input[index];
						index++;
					}
				}

				//Takes the multiblication from the search string and moves it to the state string.
				foreach (Element e in elmnts)
				{
					int ind = 0;
					while (Sort.isNum(e.search[ind]))
					{
						temp += e.search[ind];
						ind++;
					}
					if (ind > 0)
					{
						e.mult = double.Parse(temp);
						e.search = e.search.Remove(0, ind);
						temp = "";
					}
				}
				

				if (reverse)
				{
					elmnts.Reverse();
				}


				//Searches the data file and stores the relavent data in the Element objects.
				foreach (Element element in elmnts)
				{
					bool found = true;
					index = 0;
					while (index < s.Length)
					{
						if (s[index].Contains("&" + element.search + "&"))
						{
							if (s[index].Contains(":" + element.state + ":"))
							{
								Data.WriteLine("Found molecule " + s[index]);
								break;
							}
							else
							{
								index++;
							}
						}
						else
						{
							index++;
						}
					}

					//Checks a second time to see if there is an element with unspecified state
					if (index.Equals(s.Length))
					{
						index = 0;
						while (index < s.Length)
						{
							if (s[index].Contains("&" + element.search + "&"))
							{
								if (s[index].Contains(":aq:"))
								{
									element.state = "aq";
									Data.WriteLine("Found " + element.search + ". Assuming " + element.search + "'s state of matter to be " + element.state);
								}
								else if (s[index].Contains(":g:"))
								{
									element.state = "g";
									Data.WriteLine("Found " + element.search + ". Assuming " + element.search + "'s state of matter to be " + element.state);
								}
								else if (s[index].Contains(":l:"))
								{
									element.state = "l";
									Data.WriteLine("Found " + element.search + ". Assuming " + element.search + "'s state of matter to be " + element.state);
								}
								else if (s[index].Contains(":s:"))
								{
									element.state = "s";
									Data.WriteLine("Found " + element.search + ". Assuming " + element.search + "'s state of matter to be " + element.state);
								}
								else
								{
									Data.WriteLine("Found unspecified state of matter for " + element.search);
								}
								break;
							}
							else
							{
								index++;
							}
						}

						if (index.Equals(s.Length))
						{
							//Trying to guess
							index = 0;
							while (index < s.Length)
							{
								index = 0;
								while (index < s.Length)
								{
									if (s[index].Contains(element.search))
									{
										if (s[index].Contains(":" + element.state + ":"))
										{
											Data.WriteLine("Assuming " + element.search + " to be " + s[index]);
											break;
										}
										else
										{
											index++;
										}
									}
									else
									{
										index++;
									}
								}
							}

							if (index.Equals(s.Length))
							{
								//One last try by guessing
								index = 0;
								while (index < s.Length)
								{
									if (s[index].Contains(element.search))
									{
										if (s[index].Contains(":aq:"))
										{
											element.state = "aq";
											Data.WriteLine("Assuming " + element.search + " to be " + s[index] + " with the matter state " + element.state);
										}
										else if (s[index].Contains(":g:"))
										{
											element.state = "g";
											Data.WriteLine("Assuming " + element.search + " to be " + s[index] + " with the matter state " + element.state);
										}
										else if (s[index].Contains(":l:"))
										{
											element.state = "l";
											Data.WriteLine("Assuming " + element.search + " to be " + s[index] + " with the matter state " + element.state);
										}
										else if (s[index].Contains(":s:"))
										{
											element.state = "s";
											Data.WriteLine("Assuming " + element.search + " to be " + s[index] + " with the matter state " + element.state);
										}
										else
										{
											Data.WriteLine("Assuming " + element.search + "  to be " + s[index] + " Found with unspecified state of matter");
										}
										break;
									}
									else
									{
										index++;
									}
								}

								if (index.Equals(s.Length))
								{
									Data.WriteLine("ERROR: Element " + element.search + " does not exist. Check your input, or see if the molecule is listed in the datasheet");
									element.foundG = element.foundH = element.foundS = found = false;
									break;
								}
							}
						}
					}
					
					if (found)
					{
						index++;
						//Gets the molar enthalpy
						temp = s[index];
						if (temp.Equals("-"))
						{
							element.foundH = false;
							element.H = 0;
						}
						else
						{
							element.H = double.Parse(temp);
						}


						//Gets the molar entropy
						index++;
						temp = s[index];
						if (temp.Equals("-"))
						{
							element.foundS = false;
							element.S = 0;
						}
						else
						{
							element.S = double.Parse(temp);
						}


						//Gets the molar gibbs energy
						index++;
						temp = s[index];
						if (temp.Equals("-"))
						{
							element.foundG = false;
							element.G = 0;
						}
						else
						{
							element.G = double.Parse(temp);
						}

					}
					//Does the calculations
				}
				elmntsIsNotEmpty = true;
				calcDelta();
			}
		}


		//Does the calculations
		public static void calcDelta()
		{
			//Calculated the molekular change of H, G and S
			//Sort.calcDelta();
			reacSum = prodSum = 0;
			for (int q = elmnts.Count - 1; q >= 0; q--)
			{
				if (q<arrowAt)
				{
					reacSum += elmnts[q].H* elmnts[q].mult;
				}
				else
				{
					prodSum += elmnts[q].H* elmnts[q].mult;
				}
			}
			deltH = prodSum - reacSum;

			reacSum = prodSum = 0;
			for (int q = elmnts.Count - 1; q >= 0; q--)
			{
				if (q<arrowAt)
				{
					reacSum += elmnts[q].G* elmnts[q].mult;
				}
				else
				{
					prodSum += elmnts[q].G* elmnts[q].mult;
				}
			}
			deltG = prodSum - reacSum;

			reacSum = prodSum = 0;
			for (int q = elmnts.Count - 1; q >= 0; q--)
			{
				if (q<arrowAt)
				{
					reacSum += elmnts[q].S* elmnts[q].mult;
				}
				else
				{
					prodSum += elmnts[q].S* elmnts[q].mult;
				}
			}
			deltS = prodSum - reacSum;

			//Δ
			Data.WriteLine(line);
			Data.Write("Name:\t");
			foreach (Element e in elmnts)
			{
				Data.Write("|" + e.search + "\t\t");
			}
			Data.WriteLine();
			Data.Write("H:\t");
			foreach (Element e in elmnts)
			{
				if (e.foundH)
				{
					Data.Write("|" + e.H + "\t\t");
				}
				else
				{
					Data.Write("|MISSING!");
				}
			}
			Data.WriteLine();
			Data.Write("G:\t");
			foreach (Element e in elmnts)
			{
				if (e.foundG)
				{
					Data.Write("|" + e.G + "\t\t");
				}
				else
				{
					Data.Write("|MISSING!");
				}
			}
			Data.WriteLine();
			Data.Write("S:\t");
			foreach (Element e in elmnts)
			{
				if (e.foundS)
				{
					Data.Write("|" + e.S + "\t\t");
				}
				else
				{
					Data.Write("|MISSING!");
				}
			}

			//Devided by thousand because the unit needs to be kJ, but is J.
			deltGT = (deltH - (Main.ThisForm.getTemp() * deltS / 1000));


			Data.WriteLine();
			Data.WriteLine(line);
			Data.WriteLine("ΔHᴼ=" + deltH + "kJ/Mol");
			Data.WriteLine("ΔGᴼ=" + deltG + "kJ/Mol");
			Data.WriteLine("ΔG =" + deltGT + "kJ/Mol");
			Data.WriteLine("ΔSᴼ=" + deltS + "J/(Mol*K)");
			Data.WriteLine(line);

			Main.ThisForm.setH(deltH);
			Main.ThisForm.setG(deltG);
			Main.ThisForm.setS(deltS);
			Main.ThisForm.setGT(deltGT);

			Equlibrium.calcK(elmnts, arrowAt);
		}
	}
}
