using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DB
{
	public class User:BaseEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(4)]
		public string UserName { get; set; }
		[DataType(DataType.Password)]
		[MinLength(4)]
		public string Password { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime Created { get; set; }
		public List<ToDoList> ToDoLists { get; set; }
	}
}
