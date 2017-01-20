using IO.Swagger.Api;
using IO.Swagger.Client;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
			var basepath = "http://localhost/ToDoWebApi";
			var client = new RestClient(basepath);

			RestRequest req = new RestRequest("Token", Method.POST);
			req.AddParameter("username", "admin");
			req.AddParameter("password", "1111");
			req.AddParameter("grant_type", "password");
			var resp=client.Execute(req);
			dynamic data = JObject.Parse(resp.Content);
			var token = data.access_token;
            var apiCLient = new ApiClient();

            var itemApi = new ToDoItemApi(basepath);
			itemApi.AddDefaultHeader("Authorization", "bearer " + token);


			var items = itemApi.ToDoItemGetAll();

            var rnd = new Random();
            int id = rnd.Next(items.Count);

            itemApi.ToDoItemMarkAsCompleted(id);
        }
    }
}
