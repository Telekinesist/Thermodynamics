using System;
using System.Collections.Generic;
using System.Net;

namespace Thermodynamics
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.Unicode;
			string input = "";
			while (!input.Equals("exit"))
			{
				explain();
				input = Console.ReadLine().ToLower();
				if (input.Equals("change"))
				{
					Delta.delta();
				}
			}
		}

		static void explain()
		{
			Console.WriteLine("Choose between: Molar standart change, ");
		}
	}
}
