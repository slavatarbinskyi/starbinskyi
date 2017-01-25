using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DB
{
	public class ToDoList
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Modified { get; set; }
		public virtual List<ToDoItem> Items { get; set; }
		[ForeignKey("User_Id")]
		public virtual User User { get; set; }
		public int User_Id { get; set; }
		public ToDoList()
		{
			Items = new List<ToDoItem>();
		}
	}
}
