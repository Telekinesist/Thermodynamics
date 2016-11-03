using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Therm
{
	static class Equlibrium
	{
		public static void calcK(List<Element> Elelemts)
		{
			Form1 Form = Form1.ThisForm;
			double K = Math.Pow(Math.E, ((-1)*Form.getG())/(Form.getR()*Form.getTemp()));
			Form.setK(K);
		}
	}
}
