using IO.Swagger.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	class Programx
	{
		static void Main(string[] args)
		{
			ToDoItemApi toDoItemApi = new ToDoItemApi();
			var items = toDoItemApi.ToDoItemGetAll();
		}
	}
}
