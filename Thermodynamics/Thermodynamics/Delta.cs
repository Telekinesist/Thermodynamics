using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thermodynamics
{
	static class Delta
	{
		public static void delta()
		{
			string[] s;
			string input, temp;
			List<Element> elmnts = new List<Element>();
			double deltH, deltG, deltS, prodSum = 0, reacSum = 0;
			int stuff = 0, index = 0, arrowAt = 0;
			string line = "=================================================================================================================";

			//Loads data
			s = System.IO.File.ReadAllLines(@"..\Data.html");

			Console.WriteLine(line);
			Console.WriteLine("\tSYNTAX:");
			Console.WriteLine("\tTo raise, use ':'. Write numbers first. Use '2+', '5-' or just '+', but not '+2'");
			Console.WriteLine("\t\tExample: Fe:2+");
			Console.WriteLine("\tTo lower, use '_'");
			Console.WriteLine("\t\tExample: O_2");
			Console.WriteLine("\tElements are case sentisive and space is ignored. Remember the states of matter.\n\tThis program support any amounts of elements, but no numbers larger than 9");
			Console.WriteLine("\tRemember to check no values are noted as MISSING");
			Console.WriteLine("\n\tSyntax example burning of hydrogen:");
			Console.WriteLine("\t2H_2O(g) + O_2(g) -> 2H_2O(g)");
			Console.WriteLine(line + "\n");

			//Takes user input
			input = Console.ReadLine().ToLower();

			while (!input.Equals("exit") || !input.Equals("back"))
			{
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


				if (input.ToLower().Equals("update"))
				{
					//Updates stored dodument with data online if possible
					try
					{
						using (WebClient client = new WebClient())
						{
							System.IO.File.WriteAllText(@"..\Data.html", client.DownloadString("http://bilbo.chm.uri.edu/CHM112/tables/thermtable.htm"));
						}
						s = System.IO.File.ReadAllLines(@"..\Data.html");
						foreach (string textLine in s)
						{
							Console.WriteLine(textLine);
						}
						Console.WriteLine("Got text online");
						Console.WriteLine("Updated local data");

					}
					catch
					{
						Console.WriteLine("Unable to get data from web.");
					}
				}
				else if (input.Length < 1 || input.Length.Equals(1))
				{
					Console.WriteLine("That can't be right");
				}
				else
				{
					//creates the Element objects as well as giving them a searchable string defined by said input
					//Sort.createSearch(input);
					/**
			 * Example code for debugging. Burning of methane
			 **/
					/***elmnts.Add(new Element());
					elmnts[stuff].search = "<p>CH<sub>4</sub>(<i>g</i>)";
					elmnts[stuff].mult = 1;

					elmnts.Add(new Element());
					stuff++;
					elmnts[stuff].search = "<p>O<sub>2</sub>(<i>g</i>)";
					elmnts[stuff].mult = 2;

					arrowAt = 2;

					elmnts.Add(new Element());
					stuff++;
					elmnts[stuff].search = "<p>H<sub>2</sub>O(<i>g</i>)";
					elmnts[stuff].mult = 2;

					elmnts.Add(new Element());
					stuff++;
					elmnts[stuff].search = "<p>CO<sub>2</sub>(<i>g</i>)";
					elmnts[stuff].mult = 1;*/



					elmnts.Add(new Element());
					elmnts[stuff].search = "<p>";
					while (index < input.Length)
					{
						if (Sort.isNum(input[index]))
						{
							elmnts[stuff].mult = int.Parse(input.Substring(index, 1));
							index++;
							Console.WriteLine("Got number " + elmnts[stuff].mult);
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

						Console.WriteLine("Search for " + elmnts[stuff].search);
					}

					//Searches the data file and stores the relavent data in the Element objects.
					foreach (Element element in elmnts)
					{
						index = 0;
						while (index < s.Length && !s[index].Contains(element.search))
						{
							index++;
						}
						if (index.Equals(s.Length))
						{
							Console.WriteLine("ERROR: Element does not exist. Check your input, or if the molecule is listed in the datasheet");
							element.notFound = true;
							break;
						}
						Console.WriteLine(s[index]);
						index += 3;
						Console.WriteLine(s[index]);


						if (s[index].Contains("&#150;"))
						{
							temp = s[index].Substring(30);
							temp = temp.Replace("</p>", "").Replace(".", ",");
							element.H = -1 * double.Parse(temp);
						}
						else
						{
							temp = s[index].Substring(24);
							temp = temp.Replace("</p>", "").Replace(".", ",");
							element.H = double.Parse(temp);
						}
						Console.WriteLine("H=" + element.H);
						index += 3;

						if (s[index].Contains("&#150;"))
						{
							temp = s[index].Substring(30);
							temp = temp.Replace("</p>", "").Replace(".", ",");
							element.G = -1 * double.Parse(temp);
						}
						else
						{
							temp = s[index].Substring(24);
							temp = temp.Replace("</p>", "").Replace(".", ",");
							element.G = double.Parse(temp);
						}
						Console.WriteLine("G=" + element.G);
						index += 3;

						if (s[index].Contains("&#150;"))
						{
							temp = s[index].Substring(30);
							temp = temp.Replace("</p>", "").Replace(".", ",");
							element.S = -1 * double.Parse(temp);
						}
						else
						{
							temp = s[index].Substring(24);
							temp = temp.Replace("</p>", "").Replace(".", ",");
							element.S = double.Parse(temp);
						}
						Console.WriteLine("S=" + element.S);
					}


					//Calculated the molekular change of H, G and S
					//Sort.calcDelta();
					reacSum = prodSum = 0;
					for (int q = elmnts.Count - 1; q >= 0; q--)
					{
						Console.WriteLine("Element " + q + " " + elmnts[q].H + " " + elmnts[q].G + " " + elmnts[q].S);
						if (q < arrowAt)
						{
							reacSum += elmnts[q].H * elmnts[q].mult;
							Console.WriteLine("r" + reacSum);
						}
						else
						{
							prodSum += elmnts[q].H * elmnts[q].mult;
							Console.WriteLine("p" + prodSum);
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
					Console.WriteLine(line);
					string[] names = input.Replace(":+", ":p").Replace(":-", ":n").Replace("-", "").Replace(" ", "").Split('+', '>');
					Console.Write("Name:\t");
					foreach (string nam in names)
					{
						if (nam.Length > 6)
						{
							Console.Write("|" + nam + "\t");
						}
						else
						{
							Console.Write("|" + nam + "\t\t");
						}

					}
					Console.WriteLine();
					Console.Write("H:\t");
					foreach (Element element in elmnts)
					{
						if (element.notFound)
						{
							Console.Write("Missing!");
						}
						else if (element.G.ToString().Length > 8)
						{
							Console.Write("|" + element.H + "\t");
						}
						else
						{
							Console.Write("|" + element.H + "\t\t");
						}
					}
					Console.WriteLine();
					Console.Write("G:\t");
					foreach (Element element in elmnts)
					{
						if (element.notFound)
						{
							Console.Write("Missing!");
						}
						else if (element.G.ToString().Length > 8)
						{
							Console.Write("|" + element.G + "\t");
						}
						else
						{
							Console.Write("|" + element.G + "\t\t");
						}
					}
					Console.WriteLine();
					Console.Write("S:\t");
					foreach (Element element in elmnts)
					{
						if (element.notFound)
						{
							Console.Write("Missing!");
						}
						else if (element.G.ToString().Length > 8)
						{
							Console.Write("|" + element.S + "\t");
						}
						else
						{
							Console.Write("|" + element.S + "\t\t");
						}
					}
					Console.WriteLine();
					Console.WriteLine(line);
					Console.WriteLine("delta_H=" + deltH + "kJ/Mol");
					Console.WriteLine("delta_G=" + deltG + "kJ/Mol");
					Console.WriteLine("delta_S=" + deltS + "J/Mol*K");
					Console.WriteLine(line);

					Data.deltaG = deltG;
					Data.deltaH = deltH;
					Data.deltaS = deltS;

				}
				input = Console.ReadLine().ToLower();
			}
		}
	}
}
