using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
	internal class Repository<T>
	{
		private List<T> data = new List<T>();

		public void AddElement(T element)
		{
			if (element != null)
			{
				data.Add(element);
			}
		}

		public T GetElement(int index)
		{
			if (index < data.Count && index > -1)
			{
				return data[index];
			}
			else
			{
				return default;
			}
		}
	}

	public class Repository<TKey, TValue>
	{
		private Dictionary<TKey, TValue> data = new Dictionary<TKey, TValue>();

		public void AddElement(TKey key, TValue value)
		{
			if (data != null)
			{
				data.Add(key, value);
			}
		}

		public TValue GetElement(TKey key)
		{
			if (data.TryGetValue(key, out TValue value))
			{
				return value;
			}
			else
			{
				return default;
			}
		}
	}
}
