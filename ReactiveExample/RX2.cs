using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExample
{
	internal static class RX2
	{
		public static void Run()
		{
			//IObservable<int> source = Observable.Range(1, 10);
			IEnumerable<int> elements = new List<int> { 1, 2, 5, 10, 20, 50, 100 };
			IObservable<int> source = elements.ToObservable();

			IObserver<int> observer = Observer.Create<int>(
				x => Console.WriteLine($"next value: {x}"),
				ex => Console.WriteLine($"on error: {ex.Message}"),
				() => Console.WriteLine("on complete")
			);

			var subscriber = source.Subscribe(observer);
			subscriber.Dispose();
			Console.ReadKey();
		}
	}
}
