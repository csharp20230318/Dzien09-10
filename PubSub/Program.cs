using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PubSub
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Publisher2 pub2 = new Publisher2();
			pub2.OnChange += Pub2_OnChange;
			pub2.OnChange += (sender, e) => Console.WriteLine($"a tu odebrano: {e.Value}");
			pub2.Raise(123);
			pub2.Raise(456);
			Console.ReadKey();

			Publisher1 pub1 = new Publisher1();
			pub1.OnChange += Pub1_OnChange;
			pub1.OnChange += () => Console.WriteLine("Kolejne wywołanie z Publisher 1");
			pub1.Raise();
			Console.ReadKey();
		}

		private static void Pub2_OnChange(object sender, MyEventArgs e)
		{
            Console.WriteLine($"Odebrana wartość: {e.Value}");
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
		public event EventHandler<MyEventArgs> OnChange = delegate { };

		public void Raise(int val)
		{
			OnChange(this, new MyEventArgs() { Value = val });
		}
	}


}
