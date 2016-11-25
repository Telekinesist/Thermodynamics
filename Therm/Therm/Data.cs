using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Therm
{
	public static class Data
	{

		public static void WriteLine(string toCons = "")
		{
			Main.ThisForm.write(toCons+"\n");
		}
		public static void Write(string toCons = "")
		{
			Main.ThisForm.write(toCons);
		}

		public static void showInstructions()
		{
			string line = "=================================================================================================================";

			Data.WriteLine(line);
			Data.WriteLine("\tSYNTAX:");
			Data.WriteLine("\tTo raise, use ':'. Write numbers first. Use '+2', '-5' or just '+' or '-', but not '2+'");
			Data.WriteLine("\t\tExample: Fe:+3");
			Data.WriteLine("\tTo lower, use '_'");
			Data.WriteLine("\t\tExample dioxygen: O_2");
			Data.WriteLine("\tElements are case sentisive and space is ignored. Remember the state of matter");
			Data.WriteLine("\tRemember to check no values are noted as MISSING");
			Data.WriteLine("\n\tSyntax example burning of hydrogen:");
			Data.WriteLine("\t2H_2(g) + O_2(g) -> 2H_2O(g) ");
			Data.WriteLine("\t2H2(g) + O2(g) -> 2H2O(g)");
			Data.WriteLine(line + "\n");
		}
	}
}
