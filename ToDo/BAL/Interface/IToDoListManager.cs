using Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
	public interface IToDoListManager
	{
		void InsertList(ToDoList list);
		List<ToDoList> GetAll();
		void UpdateList(ToDoList list);
		void RemoveList(ToDoList list);
		ToDoList GetById(int id);
		void SetName(int id, string newName);
	}
}
