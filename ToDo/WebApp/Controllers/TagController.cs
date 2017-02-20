using System;
using System.Linq;
using System.Web.Http;
using BAL.Interface;
using Model.DB;
using NLog;

namespace WebApp.Controllers
{
	[RoutePrefix("api/Tag")]
	[Authorize]
	public class TagController : ApiController
	{
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		private readonly ITagManager tagManager;

		public TagController(ITagManager tagManager)
		{
			this.tagManager = tagManager;
		}
		/// <summary>
		/// Get all tags
		/// </summary>
		/// <returns></returns>
		[Route("GetAll")]
		[HttpGet]
		public IHttpActionResult GetAll()
		{
			try
			{
				var tags = tagManager.GetAll().ToList();
				return Ok(tags);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}

		/// <summary>
		/// Add tag
		/// </summary>
		/// <param name="Name"></param>
		/// <param name="listId"></param>
		/// <returns></returns>
		[Route("AddTag/{Name}/{listId}")]
		[HttpPost]
		public IHttpActionResult AddTag(string Name, int listId)
		{
			try
			{
				var tag = new Tag {Name = Name};
				tagManager.AttachTag(tag, listId);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}

		/// <summary>
		///     Method for removing tag from db;
		/// </summary>
		/// <param name="Name"></param>
		[HttpDelete]
		[Route("RemoveTag/{Name}/{listId}")]
		public IHttpActionResult RemoveTag(string Name, int listId)
		{
			try
			{
				tagManager.RemoveTagList(Name, listId);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
	}
}