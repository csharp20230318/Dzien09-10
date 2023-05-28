using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;

namespace ZeroMQ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			new Thread(
				() =>{
					// implementacja
					Console.WriteLine("Odpalam publishera");
					Random rnd = new Random();

					using (PublisherSocket pubSocket = new PublisherSocket())
					{
						// przypięcie do portu TCP
						pubSocket.Bind("tcp://*:12345");
						for (int i = 0; i < 100; i++)
						{
							string topic = rnd.NextDouble() > 0.5 ? "topicA" : "topicB";
							string msg = $"{topic} - {i}";
							pubSocket.SendMoreFrame(topic).SendFrame(msg);
                            Console.WriteLine($"PUBLISHER: {msg}");
							Thread.Sleep(1000);
                        }						
					}
				}
			).Start();

			// implementacja subskrybenta
			using (var subSocket = new SubscriberSocket())
			{
				subSocket.Connect("tcp://localhost:12345");
				//subSocket.SubscribeToAnyTopic();
				subSocket.Subscribe("topicA");
                Console.WriteLine("odbieram komunikaty");
				while (true)
				{
					string topic = subSocket.ReceiveFrameString();
					string msg = subSocket.ReceiveFrameString();
                    Console.WriteLine($"odebrano : {topic} | {msg}");
                }
            }

			Console.ReadKey();

		}
	}
}
