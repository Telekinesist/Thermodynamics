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
			Data.WriteLine("\t<number of molecules><formula>(<state form>)");
			Data.WriteLine("\tIon charches must have + or - first.");
			Data.WriteLine("\t\tExample: Fe+3");
			Data.WriteLine("\tElements are case sentisive and space is ignored exept that you MUST write \" + \" instead of \"+\" between molecules");
			Data.WriteLine("\tRemember to check no values are noted as MISSING in this log");
			Data.WriteLine("\n\tSyntax example burning of hydrogen:");
			Data.WriteLine("\t\t2H2(g) + O2(g) -> 2H2O(g)");
			Data.WriteLine(line + "\n");
		}
	}
}
