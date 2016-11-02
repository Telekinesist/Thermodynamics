using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Therm
{
	public static class Data
	{
		public static double deltaH = 0, deltaG = 0, deltaS = 0;
		public static int kelvin = 293;


		public static void WriteLine(string toCons = "")
		{
			Form1.ThisForm.write(toCons+"\n");
		}
		public static void Write(string toCons = "")
		{
			Form1.ThisForm.write(toCons);
		}
	}
}
