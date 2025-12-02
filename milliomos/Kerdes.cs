using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace milliomos
{
	internal class Kerdes
	{
		public string Quiz {  get; set; }
		public string ValaszA { get; set; }
		public string ValaszB { get; set; }
		public string ValaszC { get; set; }
		public string ValaszD { get; set; }
		public string ValaszHelyes { get; set; }

		public Kerdes(string kerdes, string a, string b, string c, string d, string helyes) {
			Quiz = kerdes;
			ValaszA = a;
			ValaszB = b;
			ValaszC = c;
			ValaszD = d;
			ValaszHelyes = helyes;
		}

		public override string ToString()
		{
			return $"{Quiz} - {ValaszA}, {ValaszB}, {ValaszC}, {ValaszD} - {ValaszHelyes}";
		}
	}
}
