using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformExamples.GUIControls.Model
{
	class School
	{
		public string Name { get; set; }
		public string Address { get; set; }
		
		public override string ToString()
		{
			return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
		}
	}
}
