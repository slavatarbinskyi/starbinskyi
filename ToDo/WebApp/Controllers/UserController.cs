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
    public class UserController : ApiController
    {
		private IUserManager userManager;
		public UserController(IUserManager userManager)
		{
			this.userManager = userManager;
		}
		/// <summary>
		/// Get All users from database;
		/// </summary>
		public IEnumerable<User> GetAll()
		{
			var users = userManager.GetAll();
			return users;
		}
		/// <summary>
		/// Update user in database;
		/// </summary>
		/// <param name="user"></param>
		[HttpPut]
		public void UpdateUser(User user)
		{
			userManager.UpdateUser(user);
		}
		/// <summary>
		/// Insert user in database;
		/// </summary>
		/// <param name="user"></param>
		[HttpPost]
		public void InsertUser(User user)
		{
			userManager.Insert(user);
		}
		/// <summary>
		/// Get user by email;
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public User GetByEmail(string email)
		{
			return userManager.GetByEmail(email);
		}
		/// <summary>
		/// Remove user from database;
		/// </summary>
		/// <param name="user"></param>
		[HttpDelete]
		public void RemoveUser(User user)
		{
			userManager.RemoveUser(user);
		}
	}
}
