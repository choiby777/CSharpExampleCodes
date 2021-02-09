using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformExamples.GUIControls.Model
{
	class Class
	{
		public School School { get; private set; }
		public int ClassNumber { get; set; }
		public string Location { get; set; }

		public Class(School school)
		{
			School = school;
		}

		public override string ToString()
		{
			return $"{nameof(School)}: {School}, {nameof(ClassNumber)}: {ClassNumber}, {nameof(Location)}: {Location}";
		}
	}
}
