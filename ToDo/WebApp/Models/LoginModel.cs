﻿namespace WebApp.Models
{
	public class LoginModel
	{
		private string name;
		private string password;

		public string Name
		{
			get { return name; }
			set { name = value?.Trim(); }
		}

		public string Password
		{
			get { return password; }
			set { password = value?.Trim(); }
		}
	}
}