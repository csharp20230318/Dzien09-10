using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLogTest
{
	internal class Program
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		static void Main(string[] args)
		{
			logger.Trace("Trace");
			logger.Debug("Debug");
			logger.Info("Info");
			logger.Warn("Warn");
			logger.Error("Error");
			logger.Fatal("Fatal");
			Console.ReadKey();
		}
	}
}
