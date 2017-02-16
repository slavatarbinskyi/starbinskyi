using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
	public class SetNotifyDTO
	{
		public DateTime Date { get; set; }
		public int ItemId { get; set; }
		public bool NewValue { get; set; }
	}
}
