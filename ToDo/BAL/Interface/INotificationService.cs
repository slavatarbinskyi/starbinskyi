﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DB;

namespace BAL.Interface
{
	public interface INotificationService
	{
		bool NotifyOnEmail(string email, string password);
	}
}
