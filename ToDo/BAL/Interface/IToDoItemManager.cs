﻿using Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
	public interface IToDoItemManager
	{
		void InsertItem(ToDoItem item);
		List<ToDoItem> GetAll();
		void UpdateItem(ToDoItem item);
		void RemoveItem(ToDoItem item);
		void MarkAsCompleted(int id);
		List<ToDoItem> GetAllNotCompleted();
		ToDoItem GetById(int id);
		void ChangeIsCompletedValue(string id, string newValue);

	}
}
