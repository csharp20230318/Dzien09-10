using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
	public class MyStorage<T>
	{
		protected T Data { get; set; }

	}

	public class MyOwnStorage<T> : MyStorage<T>
	{

	}

	public class MyIntStorage : MyStorage<int>
	{

	}
}
