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
    public class ToDoListController : ApiController
    {
		private IToDoListManager toDoListManager;
		public ToDoListController(IToDoListManager toDoListManger)
		{
			this.toDoListManager = toDoListManger;
		}

		/// <summary>
		/// Get All lists from database;
		/// </summary>
		public IEnumerable<ToDoList> GetAll()
		{
			var lists = toDoListManager.GetAll();
			return lists;
		}
		/// <summary>
		/// Update list in database;
		/// </summary>
		[HttpPut]
		public void UpdateList(ToDoList list)
		{
			toDoListManager.UpdateList(list);
		}
		/// <summary>
		/// Insert list in database;
		/// </summary>
		[HttpPost]
		public void InsertList(ToDoList list)
		{
			toDoListManager.InsertList(list);
		}
		/// <summary>
		/// Remove list from database;
		/// </summary>
		[HttpDelete]
		public void RemoveList(ToDoList list)
		{
			toDoListManager.RemoveList(list);
		}
		/// <summary>
		/// Get by id list;
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ToDoList GetById(int id)
		{
			return toDoListManager.GetById(id);
		}
	}
}
