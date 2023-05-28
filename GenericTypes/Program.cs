using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
	delegate T Operation<T>(T a, T b);

	internal class Program
	{

		static int Add(int a, int b)
		{
			return a + b;
		}

		static void Main(string[] args)
		{

			MyStorage<string> myStorage1 = new MyStorage<string>();
			MyOwnStorage<char> myStorage2 = new MyOwnStorage<char>();
			MyIntStorage myStorage3 = new MyIntStorage();

			Operation<int> oper1 = new Operation<int>(Add);
			Console.WriteLine(oper1(2,3));

			Operation<double> oper2 = new Operation<double>( (m1, m2) => m1*m2 );
			Console.WriteLine(oper2(-2.5, 2.5));

			string a = "ABC";
			string b = "XYZ";
			Console.WriteLine($"a={a}, b={b}");
			Utils.Swap(ref a, ref b);
            Console.WriteLine($"a={a}, b={b}");

			int x = 10, y = 20;
			Console.WriteLine($"x={x}, y={y}");
			Utils.Swap(ref x, ref y);
			Console.WriteLine($"x={x}, y={y}");

			var resultsRestaurant = new PaginatedResult<Restaurant>();
			var resultUser = new PaginatedResult<User>();

			//var stringRepo = new Repository<string>();
			//stringRepo.AddElement("hello world!");

			var userRepo = new Repository<User>();
			userRepo.GetElement(-1);

			var restaurantRepo = new Repository<Restaurant>();

			//var intRepo = new Repository<int>();
			//intRepo.AddElement(10);

			var restRepo = new Repository<char, Restaurant>();
			restRepo.AddElement('a', new Restaurant());
		}
	}
}
