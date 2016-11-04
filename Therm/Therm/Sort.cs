using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Therm
{
	static class Sort
	{
		public static List<Element> elmnts = new List<Element>();
		public static double prodSum = 0, reacSum = 0;
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
	}
}
