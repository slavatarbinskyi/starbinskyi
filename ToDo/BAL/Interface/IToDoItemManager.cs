using System.Collections.Generic;
using Model.DB;

namespace BAL.Interface
{
	public interface IToDoItemManager
	{
		ToDoItem InsertItem(ToDoItem item);
		List<ToDoItem> GetAll();
		void UpdateItem(ToDoItem item);
		void RemoveItem(int? id);
		void MarkAsCompleted(int id);
		List<ToDoItem> GetAllNotCompleted();
		ToDoItem GetById(int id);
		void ChangeIsCompletedValue(int id, bool newValue);
		void SetText(int id, string newName);
		void SetNotification(int itemId);
		void DismissNotification(int itemId);
		void MarkAsNotified(string name);
	}
}