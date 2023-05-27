using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExample
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ReflectionTest.fieldA = 1;
			ReflectionTest.fieldB = 1.23;
			ReflectionTest.fieldC = "AAAA";
			ReflectionTest.fieldD = true;
			//ReflectionTest.Lookup();

			CreateObject();

		}

		static void CreateObject()
		{
			Type type = typeof(ReflectionClass);
			object obj = Activator.CreateInstance(type);
			ReflectionClass castedClass = obj as ReflectionClass;
			if (castedClass != null)
			{
                Console.WriteLine($"{castedClass.fieldA}, {castedClass.fieldB}");
            }
		}
	}
}
