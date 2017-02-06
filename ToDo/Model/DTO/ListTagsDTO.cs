using Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
	public class ListTagsDTO
	{
		public ListTagsDTO()
		{
			Tags = new List<Tag>();
			Items = new List<ToDoItem>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public int User_Id { get; set; }
		public List<ToDoItem> Items { get; set; }
		public List<Tag> Tags { get; set; }
	}
}
