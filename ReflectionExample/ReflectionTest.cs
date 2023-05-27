using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExample
{
	public static class ReflectionTest
	{
		public static int fieldA;
		public static double fieldB;
		public static string fieldC;
		public static bool fieldD;
		private static DateTime fieldE = DateTime.UtcNow;


		public static int Test1() { return 1; }
		private static double Test2() { return 1.23; }
		public static bool Test3() { return false; }

		public static void Lookup()
		{
			Type type = typeof(ReflectionTest);
			FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
			foreach (var field in fields)
			{
				string name = field.Name;
				object obj = field.GetValue(null);

                Console.WriteLine($"[{name}] - {obj}");
            }

			MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
			foreach (var method in methods)
			{
                Console.WriteLine($"[{method.Name}] - {method.ReturnType}");
            }
		}
	}
}
