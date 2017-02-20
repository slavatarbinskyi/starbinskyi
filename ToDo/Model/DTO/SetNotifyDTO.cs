using System;

namespace Model.DTO
{
	public class SetNotifyDTO
	{
		public DateTime Date { get; set; }
		public int ItemId { get; set; }
		public bool NewValue { get; set; }
	}
}