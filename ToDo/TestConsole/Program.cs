using System;
using System.Collections.Generic;
using Model.DB;
using RestSharp;

namespace TestConsole
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var client = new RestClient("http://localhost:8778/");
			var request = new RestRequest("api/ToDoItem/GetAll", Method.GET);
			var queryResult = client.Execute<List<ToDoItem>>(request).Data;
			var random = new Random();
			var r = random.Next(queryResult.Count);
			var id = queryResult[r].Id;
			var requestPut = new RestRequest("api/ToDoItem/MarkAsCompleted/?Id=" + id, Method.PUT);
			client.Execute(requestPut);
		}
	}
}