using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
	public class User
	{

	}

	public class Restaurant
	{

	}

	public class UserResults
	{
		public List<User> Users { get; set; }
		public int ResultsFrom { get; set; } //1
		public int ResultsTo { get; set; } //50
		public int TotalResults { get; set; } // 123
	}

	public class RestaurantResults
	{
		public List<Restaurant> Restaurants { get; set; }
		public int ResultsFrom { get; set; } //1
		public int ResultsTo { get; set; } //50
		public int TotalResults { get; set; } // 123
	}

	public abstract class AbstractResults
	{
		public int ResultsFrom { get; set; } //1
		public int ResultsTo { get; set; } //50
		public int TotalResults { get; set; } // 123
	}

	public class UserAbstractResults : AbstractResults
	{
		List<User> Users { get; set; }
	}

	public class RestaurantAbstractResults : AbstractResults
	{
		List<Restaurant> Restaurants { get; set; }
	}

}