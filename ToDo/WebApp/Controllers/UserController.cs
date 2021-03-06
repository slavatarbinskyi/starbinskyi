﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BAL.Interface;
using Model.DB;
using NLog;

namespace WebApp.Controllers
{
	public class UserController : ApiController
	{
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		private readonly IUserManager userManager;

		public UserController(IUserManager userManager)
		{
			this.userManager = userManager;
		}

		/// <summary>
		///     Get All users from database
		/// </summary>
		[ResponseType(typeof(List<User>))]
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
		///     Update user in database
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
		///     Insert user in database
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
		///     Get user by email
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		[ResponseType(typeof(User))]
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
		///     Remove user from database
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