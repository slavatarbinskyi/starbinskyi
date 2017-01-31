﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DB
{
	public class InviteUser
	{
		[Key]
		public int Id { get; set; }
		public string Email { get; set; }
		public string GuidId { get; set; }
	}
}
