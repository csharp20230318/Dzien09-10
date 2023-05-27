using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Publisher1 pub1 = new Publisher1();
			pub1.OnChange += Pub1_OnChange;
			pub1.OnChange += () => Console.WriteLine("Kolejne wywołanie z Publisher 1");
			pub1.Raise();
			Console.ReadKey();
		}

		private static void Pub1_OnChange()
		{
            Console.WriteLine("invoke Pub1_OnChange");
        }
	}

	class MyEventArgs : EventArgs
	{
		public int Value { get; set; }
	}

	class Publisher1
	{
		public event Action OnChange = delegate { };

		public void Raise()
		{
			OnChange();
		}
	}

	class Publisher2
	{

	}


}
