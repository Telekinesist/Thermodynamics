using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thermodynamics
{
	static class Sort
	{
		public static List<Element> elmnts = new List<Element>();
		public static double deltH, deltG, deltS, prodSum = 0, reacSum = 0;
		public static int stuff = 0, index = 0, arrowAt = 0;



		public static bool isNum(char test)
		{
			if (test.Equals('1') ||
				test.Equals('2') ||
				test.Equals('3') ||
				test.Equals('4') ||
				test.Equals('5') ||
				test.Equals('6') ||
				test.Equals('7') ||
				test.Equals('8') ||
				test.Equals('9'))
			{
				return true;
			}
			else
			{
				return false;
			}
		}



		public static void createSearch(string input)
		{
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
						elmnts[stuff].search += "<sup>" + "&#150;" + " </sup>";
						index += 1;
					}
					else
					{
						index++;
						elmnts[stuff].search += "<sup>" + input.Substring(index, 2) + "</sup>";
						index += 2;
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
						elmnts[stuff].search += "(<i>" + input.Substring(index + 1, 1) + "</i>)";
						index += 3;
					}
					else if (input.Substring(index + 1, 2).Equals("aq"))
					{
						elmnts[stuff].search += "(<i>" + input.Substring(index + 1, 2) + "</i>)";
						index += 4;
					}
				}
				else if (input[index].Equals('-'))
				{
					index++;
					if (input[index].Equals('>'))
					{
						elmnts.Add(new Element());
						stuff++;
						index++;
						arrowAt = stuff;
						elmnts[stuff].search = "<p>";
					}

				}
				else
				{
					elmnts[stuff].search += input[index];
					index++;
				}

				Console.WriteLine("Search for " + elmnts[stuff].search);
			}

		}



		public static void calcDelta()
		{
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
		}
	}
}
