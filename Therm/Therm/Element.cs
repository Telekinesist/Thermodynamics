using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Therm
{
	class Element
	{
		public string search;
		public string state = "(";
		public int mult = 1;
		public double H, S, G;
		public bool notFound = false;
		public Element()
		{

		}
	}
}
