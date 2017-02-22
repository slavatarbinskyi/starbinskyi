using System.Collections.Generic;
using System.Data.Entity.Spatial;
using Model.DB;
using Model.DTO;

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
		List<ListTagsDTO> GetListsByTagName(string Name);
		void AttachToLocation(List<int> ids, DbGeography location);
		List<LocationDTO> GetPoints();
	}
}