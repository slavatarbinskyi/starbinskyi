﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.DB
{
	public class ToDoItem : BaseEntity
	{
		[Key]
		public int Id { get; set; }

		public string Text { get; set; }
		public int? Priority { get; set; }
		public bool IsCompleted { get; set; }
		public bool? IsNotify { get; set; }
		public DateTime? NextNotifyTime { get; set; }

		[ForeignKey("ToDoList_Id")]
		public virtual ToDoList ToDoList { get; set; }

		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime Created { get; set; }

		public int ToDoList_Id { get; set; }
	}
}