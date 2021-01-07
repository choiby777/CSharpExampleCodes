using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extention
{
	public static class StringExtention
	{
		public static bool HasValue(this string source)
		{
			return string.IsNullOrEmpty(source) == false;
		}

		public static bool IsNullOrEmpty(this string source)
		{
			return string.IsNullOrEmpty(source);
		}

		public static string Reverse(this string input)
		{
			char[] chars = input.ToCharArray();
			Array.Reverse(chars);
			return new String(chars);
		}

		public static string RemoveLastCharacter(this String instr)
		{
			return instr.Substring(0, instr.Length - 1);
		}

		public static string RemoveLast(this String instr, int number)
		{
			return instr.Substring(0, instr.Length - number);
		}

		public static string RemoveFirstCharacter(this String instr)
		{
			return instr.Substring(1);
		}

		public static string RemoveFirst(this String instr, int number)
		{
			return instr.Substring(number);
		}

		public static string F(this string s, params object[] args)
		{
			return string.Format(s, args);
		}

		/// <summary>
		/// Parses a string into an Enum
		/// </summary>
		/// <typeparam name="T">The type of the Enum</typeparam>
		/// <param name="value">String value to parse</param>
		/// <returns>The Enum corresponding to the stringExtensions</returns>
		public static T EnumParse<T>(this string value)
		{
			return EnumParse<T>(value, false);
		}

		/// <summary>
		/// Example : TestEnum foo = "Test".EnumParse<TestEnum>();
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <param name="ignorecase"></param>
		/// <returns></returns>
		public static T EnumParse<T>(this string value, bool ignorecase)
		{

			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			value = value.Trim();

			if (value.Length == 0)
			{
				throw new ArgumentException("Must specify valid information for parsing in the string.", "value");
			}

			Type t = typeof(T);

			if (!t.IsEnum)
			{
				throw new ArgumentException("Type provided must be an Enum.", "T");
			}

			return (T)Enum.Parse(t, value, ignorecase);
		}


		public static int ToInt(this String input, int defaultValue = 0)
		{
			int result;

			if (!int.TryParse(input, out result))
			{
				result = defaultValue;
			}

			return result;
		}

		/// <summary>
		/// MessageBox.Show(s.IfNullElse("Null Alternate Value"));
		/// </summary>
		/// <param name="input">string to check</param>
		/// <param name="nullAlternateValue">value to be returned in case string is null</param>
		/// <returns>string: original or null alternative value</returns>
		public static string IfNullElse(this string input, string nullAlternateValue)
		{
			return (!string.IsNullOrWhiteSpace(input)) ? input : nullAlternateValue;
		}

		/// <summary>
		/// string value = "abc";
		/// bool isnumeric = value.IsNumeric();// Will return false;
		/// </summary>
		/// <param name="theValue"></param>
		/// <returns></returns>
		public static bool IsNumeric(this string theValue)
		{
			long retNum;
			return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
		}
	}
}
