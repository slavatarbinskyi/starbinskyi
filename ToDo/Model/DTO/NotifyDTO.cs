using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
	public class NotifyDTO
	{
		public string ListName { get; set; }
		public string ItemName { get; set; }
		public DateTime? NotifyTime { get; set; }
		public string Email { get; set; }
	}
}
