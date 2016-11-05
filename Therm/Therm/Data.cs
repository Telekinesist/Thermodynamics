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
			Data.WriteLine("\tTo raise, use ':'. Write numbers first. Use '2+', '5-' or just '+', but not '+2'");
			Data.WriteLine("\t\tExample: Fe:2+");
			Data.WriteLine("\tTo lower, use '_'");
			Data.WriteLine("\t\tExample: O_2");
			Data.WriteLine("\tElements are case sentisive and space is ignored. Remember the states of matter.\n\tThis program support any amounts of elements, but no numbers larger than 9");
			Data.WriteLine("\tRemember to check no values are noted as MISSING");
			Data.WriteLine("\n\tSyntax example burning of hydrogen:");
			Data.WriteLine("\t2H_2(g) + O_2(g) -> 2H_2O(g) ");
			Data.WriteLine(line + "\n");
		}
	}
}
