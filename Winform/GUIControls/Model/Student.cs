using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformExamples.GUIControls.Model
{
	class Student
	{
		public string Name { get; set; }
		public DateTime BirthDate { get; set; }
		public int NumberInClass { get; set; }
		public Class classInfo { get; private set; }

		public Student(Class classInfo)
		{
			this.classInfo = classInfo;
		}

		public override string ToString()
		{
			return $"{nameof(Name)}: {Name}, {nameof(BirthDate)}: {BirthDate}, {nameof(NumberInClass)}: {NumberInClass}, {nameof(classInfo)}: {classInfo}";
		}

		public static int CompareByName(Student x, Student y)
		{
			if (x == null || y == null) // null check up front
			{
				// minor performance hit in doing null checks multiple times, but code is much more 
				// readable and null values should be a rare outside case.
				if (x == null && y == null) { return 0; } // both null
				else if (x == null) { return -1; } // only x is null
				else { return 1; } // only y is null
			}
			else { return x.Name.CompareTo(y.Name); }
		}

		public static int CompareByNameDescending(Student y, Student x)
		{
			if (x == null || y == null) // null check up front
			{
				// minor performance hit in doing null checks multiple times, but code is much more 
				// readable and null values should be a rare outside case.
				if (x == null && y == null) { return 0; } // both null
				else if (x == null) { return -1; } // only x is null
				else { return 1; } // only y is null
			}
			else { return x.Name.CompareTo(y.Name); }
		}
	}
}
