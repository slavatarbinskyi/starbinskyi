﻿using System.Collections.Generic;
using System.Linq;
using BAL.Interface;
using DAL.Interface;
using Model.DB;

namespace BAL.Manager
{
	public class UserManager : BaseManager, IUserManager
	{
		public UserManager(IUnitOfWork uOW)
			: base(uOW)
		{
		}

		/// <summary>
		///     Get all users from db.
		/// </summary>
		/// <returns></returns>
		public List<User> GetAll()
		{
			var users = new List<User>();
			foreach (var user in uOW.UserRepo.All)
			{
				var User = uOW.UserRepo.GetByID(user.Id);
				users.Add(User);
			}
			return users;
		}

		/// <summary>
		///     Get User by Email;
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public User GetByEmail(string email)
		{
			return uOW.UserRepo.All.FirstOrDefault(x => x.Email == email);
		}

		/// <summary>
		///     Update User in database.
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="UserName"></param>
		/// <param name="Password"></param>
		/// <param name="Email"></param>
		/// <param name="RoleId"></param>
		public void UpdateUser(User user)
		{
			var UserDb = uOW.UserRepo.GetByID(user.Id);
			if (UserDb == null) return;
			UserDb.UserName = user.UserName;
			UserDb.Password = user.Password;
			UserDb.Email = user.Email;
			uOW.Save();
		}

		/// <summary>
		/// Get user by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public User GetById(int id)
		{
			return uOW.UserRepo.GetByID(id);
		}

		/// <summary>
		///     Insert user into database
		/// </summary>
		/// <param name="user">User</param>
		public void Insert(User user)
		{
			if (user == null) return;
			uOW.UserRepo.Insert(user);
			uOW.Save();
		}

		/// <summary>
		///     Check the email's exictance in database
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public bool EmailIsExist(string email)
		{
			return uOW.UserRepo.All.Any(x => x.Email == email);
		}

		/// <summary>
		///     Remove user from db;
		/// </summary>
		/// <param name="item"></param>
		public void RemoveUser(User user)
		{
			if (user == null) return;
			var userDb = uOW.UserRepo.GetByID(user.Id);
			if (userDb == null) return;
			uOW.UserRepo.Delete(userDb);
			uOW.Save();
		}
		/// <summary>
		/// Find user
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public User Find(string username, string password)
		{
			var user = uOW.UserRepo.All.FirstOrDefault(i => i.UserName == username && i.Password == password);
			return user;
		}

		/// <summary>
		///     Get email of user;
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public string GetEmail(int Id)
		{
			var email = uOW.UserRepo.GetByID(Id).Email;
			return email;
		}
	}
}