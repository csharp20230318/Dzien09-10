using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReactiveExample
{
	public static class RX3
	{
		public static void Run()
		{
			IObservable<Stock> source = Observable.Create<Stock>(
				observer =>
				{
					Random rnd = new Random();
					string[] names = { "APL", "GOG", "TSL" };
					new Thread(
						() =>
						{
							int i = 10;
							while (i > 0)
							{
								string n = names[rnd.Next(0, 3)];
								double v = rnd.Next(10, 101) + rnd.NextDouble();
								//Console.WriteLine($"{n} {v}");
								if (v > 95)
								{
									observer.OnError(new Exception($"wysoka wartość: {v}"));
								}
								else
								{
									observer.OnNext(new Stock(n, v));
								}
								Thread.Sleep(1000);
								i--;
							}
							observer.OnCompleted();
						}
					).Start();
					return Disposable.Empty;
				}
			);

			IDisposable subscriber = source.Subscribe(
				x => Console.WriteLine($"next value: {x.Name} - {x.Value}"),
				ex => Console.WriteLine($"on error: {ex.Message}"),
				() => Console.WriteLine("on complete")
			);
			
			Console.ReadKey();
			subscriber.Dispose();
		}
	}

	public class Stock
	{
		public string Name;
		public double Value;

		public Stock(string name, double value)
		{
			Name = name;
			Value = value;
		}
	}
}
