using BAL.Interface;
using Model.DB;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApp.Controllers
{
	public class ToDoListController : ApiController
	{
		private IToDoListManager toDoListManager;
		private IToDoItemManager toDoItemManager;
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		public ToDoListController(IToDoListManager toDoListManger, IToDoItemManager toDoItemManager)
		{
			this.toDoListManager = toDoListManger;
			this.toDoItemManager = toDoItemManager;
		}
		
		/// <summary>
		/// Get All lists from database
		/// </summary>
		[ResponseType(typeof(List<ToDoList>))]
		public IHttpActionResult GetAll()
		{
			try
			{
				var lists = toDoListManager.GetAll();
				return Ok(lists);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
		/// <summary>
		/// Update list in database
		/// </summary>
		[HttpPut]
		public IHttpActionResult UpdateList(ToDoList list)
		{
			try
			{
				toDoListManager.UpdateList(list);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
		/// <summary>
		/// Insert list in database
		/// </summary>
		[HttpPost]
		public IHttpActionResult InsertList(ToDoList list)
		{
			try
			{
				toDoListManager.InsertList(list);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
		/// <summary>
		/// Remove list from database
		/// </summary>
		[HttpDelete]
		public IHttpActionResult RemoveList(ToDoList list)
		{
			try
			{
				toDoListManager.RemoveList(list);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
		/// <summary>
		/// Get by id list
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[ResponseType(typeof(ToDoList))]
		public IHttpActionResult GetById(int id)
		{
			try
			{
				return Ok(toDoListManager.GetById(id));
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
	}
}
