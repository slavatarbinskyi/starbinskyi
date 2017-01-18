using BAL.Interface;
using Model.DB;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class UserController : ApiController
    {
		private IUserManager userManager;
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		public UserController(IUserManager userManager)
		{
			this.userManager = userManager;
		}
		/// <summary>
		/// Get All users from database
		/// </summary>
		public IHttpActionResult GetAll()
		{
			try
			{
				var users = userManager.GetAll();
				return Ok(users);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
		/// <summary>
		/// Update user in database
		/// </summary>
		/// <param name="user"></param>
		[HttpPut]
		public IHttpActionResult UpdateUser(User user)
		{
			try
			{
				userManager.UpdateUser(user);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
		/// <summary>
		/// Insert user in database
		/// </summary>
		/// <param name="user"></param>
		[HttpPost]
		public IHttpActionResult InsertUser(User user)
		{
			try
			{
				userManager.Insert(user);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
		/// <summary>
		/// Get user by email
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public IHttpActionResult GetByEmail(string email)
		{
			try
			{
				return Ok(userManager.GetByEmail(email));
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return NotFound();
			}
		}
		/// <summary>
		/// Remove user from database
		/// </summary>
		/// <param name="user"></param>
		[HttpDelete]
		public IHttpActionResult RemoveUser(User user)
		{
			try
			{
				userManager.RemoveUser(user);
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
