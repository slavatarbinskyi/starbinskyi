using Model.DB;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
	public interface IToDoListManager
	{
		ListTagsDTO InsertList(ToDoList list);
		List<ListTagsDTO> GetAll();
		void UpdateList(ToDoList list);
		void RemoveList(int id);
		ToDoList GetById(int id);
		void SetName(int id, string newName);
	}
}
