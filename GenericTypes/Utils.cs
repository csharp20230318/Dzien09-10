using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
	public static class Utils
	{
		public static void SwapInt(ref int a, ref int b)
		{
			int tmp = a;
			a = b;
			b = tmp;
		}

		public static void Swap<T>(ref T first, ref T second)
		{
			T tmp = first;
			first = second;
			second = tmp;
		}
	}
}
