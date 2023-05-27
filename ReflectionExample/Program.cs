using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExample
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			ReflectionTest.fieldA = 1;
			ReflectionTest.fieldB = 1.23;
			ReflectionTest.fieldC = "AAAA";
			ReflectionTest.fieldD = true;
			//ReflectionTest.Lookup();

			//CreateObject();

			// ewaluacja kodu c# w czasie rzeczywistym
			string code = "var a=9; if (a>=9) { return 1;} else { return -10; } ";
			int result = await CSharpScript.EvaluateAsync<int>(code);
            Console.WriteLine(result);

            var assembly = Assembly.LoadFrom("ExternalLibrary.dll");
			foreach (var type in assembly.ExportedTypes)
			{
                Console.WriteLine("===================");
                Console.WriteLine(type.FullName);

				foreach (var ctr in type.GetConstructors())
				{
                    Console.WriteLine($"Konstruktor: {ctr.Name}");
					foreach (var ctrParam in ctr.GetParameters())
					{
                        Console.WriteLine($"{ctrParam.Name} : {ctrParam.ParameterType}");
                    }
                }

				Console.WriteLine("==================");
				Console.WriteLine("Properties");
				foreach (var prop in type.GetProperties())
				{
					Console.WriteLine($"{prop.Name} - {prop.PropertyType}");
				}

				Console.WriteLine("==================");
				Console.WriteLine("Methods");
				foreach (var method in type.GetMethods())
				{
					Console.WriteLine($"{method.Name} - {method.ReturnType}");
				}
			}

			Console.ReadKey();

		}

		public class DemoClass
		{
			private readonly double constValue = 1.23456;
			public double Show()
			{
				return constValue;
			}
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

			object[] arguments = new object[] { "Hello world!" };
			obj = Activator.CreateInstance(type, arguments);
			castedClass = obj as ReflectionClass;
			if (castedClass != null)
			{
				Console.WriteLine($"{castedClass.fieldA}, {castedClass.fieldB}");
			}

			// zmiana wartości dla pola
			PropertyInfo property = type.GetProperty("fieldB");
			if (property != null)
			{
				property.SetValue(castedClass, "ABCDEFGHIJKL");
				string newValue = property.GetValue(castedClass) as string;
				Console.WriteLine(newValue);
			}

			//wywołanie metody przy pomocy reflekacji
			MethodInfo method = type.GetMethod("MethodStr");
			if (method != null)
			{
				string result = (string)method.Invoke(castedClass, new object[0]);
				Console.WriteLine(result);
			}

			method = type.GetMethod("MethodInt");
			if (method != null)
			{
				int x = (int)method.Invoke(castedClass, new object[] { 10 });
                Console.WriteLine(x);
            }

			DemoClass dc = new DemoClass();
			FieldInfo field = typeof(DemoClass).GetField("constValue", BindingFlags.NonPublic | BindingFlags.Instance);
			if (field!=null)
			{
				field.SetValue(dc, -9.8765);
                Console.WriteLine(dc.Show());
            }
		}
	}
}
