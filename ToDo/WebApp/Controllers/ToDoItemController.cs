using BAL.Interface;
using Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class ToDoItemController : ApiController
    {
		private IToDoItemManager toDoItemManager;
		public ToDoItemController(IToDoItemManager toDoItemManager)
		{
			this.toDoItemManager = toDoItemManager;
		}
		/// <summary>
		/// Get All Items.
		/// </summary>
		/// <returns></returns>
		public HttpResponseMessage GetAll()
		{
			var items=toDoItemManager.GetAll();
			return Request.CreateResponse(HttpStatusCode.OK,items);
			//return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
			//return items;
		}
		/// <summary>
		/// Get All Not Completed Items.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<ToDoItem> GetAllNotCompleted()
		{
			var items = toDoItemManager.GetAllNotCompleted();
			return items;
		}
		/// <summary>
		/// Mark item as completed in database;
		/// </summary>
		/// <param name="Id"></param>
		[HttpPut]
		public void MarkAsCompleted(int Id)
		{
			toDoItemManager.MarkAsCompleted(Id);
		}

		/// <summary>
		/// Remove item from database;
		/// </summary>
		/// <param name="item"></param>
		[HttpDelete]
		public void RemoveItem(ToDoItem item)
		{
			toDoItemManager.RemoveItem(item);
		}

		/// <summary>
		/// Update item in database;
		/// </summary>
		/// <param name="item"></param>
		[HttpPut]
		public void UpdateItem(ToDoItem item)
		{
			toDoItemManager.UpdateItem(item);
		}

		/// <summary>
		/// Insert Item
		/// </summary>
		/// <param name="item"></param>
		[HttpPost]
		public void InsertItem(ToDoItem item)
		{
			toDoItemManager.InsertItem(item);
		}
		/// <summary>
		/// Get by id item;
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public HttpResponseMessage GetById(int Id)
		{
			var item = toDoItemManager.GetById(Id);
			if (item != null)
				return Request.CreateResponse(HttpStatusCode.OK, item);
			//return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
			throw new Exception("No item found for this id");
		}

	}
}
