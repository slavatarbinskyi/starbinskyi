using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.DB
{
	public class Tag : BaseEntity
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }

		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime Created { get; set; }
	}
}