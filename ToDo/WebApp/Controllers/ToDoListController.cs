using BAL.Interface;
using Microsoft.AspNet.Identity;
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
	[RoutePrefix("api/ToDoList")]
	[Authorize]
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

		[ResponseType(typeof(List<ToDoList>))]
		[HttpGet]
		public IHttpActionResult GetAll()
		{
			try
			{
				var userId = User.Identity.GetUserId();
				if (userId == null)
				{
					return Json(new
					{
						message = "You need to LogIn"
					});
				}
				var lists = toDoListManager.GetAll().Where(u => u.User_Id == Convert.ToInt32(userId)).ToList();
				return Ok(lists);

			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}

		/// <summary>
		/// Get lists by tag name
		/// </summary>
		/// <param name="tagName"></param>
		/// <returns></returns>
		//GET: api/ToDoList/tagName
		[HttpGet]
		[Route("GetAllByTagName/{tagName}")]
		public IHttpActionResult GetAllByTagName(string tagName)
		{
			try
			{
				var lists = toDoListManager.GetListsByTagName(tagName);

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
		[Route("InsertList")]
		public IHttpActionResult InsertList(ToDoList list)
		{
			try
			{
				list.User_Id = Convert.ToInt32(User.Identity.GetUserId());
				var result = toDoListManager.InsertList(list);
				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
		[HttpPut]
		[Route("SetName/{listId}/{newName}")]
		public IHttpActionResult SetName(int listId, string newName)
		{
			try
			{
				toDoListManager.SetName(listId, newName);
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
		public IHttpActionResult RemoveList(int id)
		{
			try
			{
				toDoListManager.RemoveList(id);
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
