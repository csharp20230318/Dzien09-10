using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExample
{
	internal static class RX1
	{
		public static void Run()
		{
			IObservable<int> source = Observable.Range(1, 10);
			IDisposable subscriber = source.Subscribe(
				x => Console.WriteLine($"next value: {x}"),
				ex => Console.WriteLine($"on error: {ex.Message}"),
				() => Console.WriteLine("on complete")
			);
			subscriber.Dispose();
			Console.ReadKey();
		}
	}
}
