using System.Collections.Generic;
using Model.DB;

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