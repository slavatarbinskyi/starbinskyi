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
using WebApp.Helpers;

namespace WebApp.Controllers
{
	[Authorize]
	public class ToDoItemController : ApiController
    {
		private IToDoItemManager toDoItemManager;
		private readonly Logger _logger =LogManager.GetCurrentClassLogger();
		public ToDoItemController(IToDoItemManager toDoItemManager)
		{
			this.toDoItemManager = toDoItemManager;
		}
		/// <summary>
		/// Get All Items.
		/// </summary>
		/// <returns></returns>
		[ResponseType(typeof(List<ToDoItem>))]
		public IHttpActionResult GetAll()
		{
			try
			{
				var items = toDoItemManager.GetAll();
				return Ok(items);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
		/// <summary>
		/// Get All Not Completed Items.
		/// </summary>
		/// <returns></returns>
		[ResponseType(typeof(List<ToDoItem>))]
		[HttpGet]
		public IHttpActionResult GetAllNotCompleted()
		{
			try
			{
				var items = toDoItemManager.GetAllNotCompleted();
				return Ok(items);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
		/// <summary>
		/// Mark item as completed in database
		/// </summary>
		/// <param name="Id"></param>
		[HttpPut]
		public IHttpActionResult MarkAsCompleted(int Id)
		{
			try
			{
				toDoItemManager.MarkAsCompleted(Id);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}

		/// <summary>
		/// Remove item from database
		/// </summary>
		/// <param name="item"></param>
		[HttpDelete]
		public IHttpActionResult RemoveItem(ToDoItem item)
		{
			try
			{
				toDoItemManager.RemoveItem(item);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}

		/// <summary>
		/// Update item in database
		/// </summary>
		/// <param name="item"></param>
		
		[HttpPut]
		public IHttpActionResult UpdateItem(ToDoItem item)
		{
			try
			{
				toDoItemManager.UpdateItem(item);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}

		/// <summary>
		/// Insert Item
		/// </summary>
		/// <param name="item"></param>
		[HttpPost]
		public IHttpActionResult InsertItem(ToDoItem item)
		{
			try
			{
				toDoItemManager.InsertItem(item);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
		/// <summary>
		/// Get by id item
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[ResponseType(typeof(ToDoItem))]
		public IHttpActionResult GetById(int Id)
		{
			try
			{
				var item = toDoItemManager.GetById(Id);
				return Ok(item);
			}
			catch(Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}

	}
}
