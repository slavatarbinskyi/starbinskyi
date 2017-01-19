using IO.Swagger.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			{
				var toDoItemApi = new ToDoItemApi();
				var items = toDoItemApi.ToDoItemGetAll();
				var random = new Random();
				int r = random.Next(items.Count);
				var id = items[r].Id;
				toDoItemApi.ToDoItemMarkAsCompleted(id);

			}
		}
	}
}
