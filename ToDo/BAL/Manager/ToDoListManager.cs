using BAL.Interface;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DB;

namespace BAL.Manager
{
	public class ToDoListManager:BaseManager,IToDoListManager
	{
		public ToDoListManager(IUnitOfWork uOW)	: base(uOW)
        {
		}

		/// <summary>
		/// Get all lists from db.
		/// </summary>
		/// <returns></returns>
		public List<ToDoList> GetAll()
		{
			return uOW.ToDoListRepo.Get(includeProperties:"Items").ToList();
		}
		/// <summary>
		/// Insert list into db.
		/// </summary>
		/// <param name="list"></param>
		public void InsertList(ToDoList list)
		{
			if (list == null) return;
			list.Created = DateTime.Now;
			uOW.ToDoListRepo.Insert(list);
			uOW.Save();
		}
		/// <summary>
		/// Remove list from db;
		/// </summary>
		/// <param name="list"></param>
		public void RemoveList(ToDoList list)
		{
			if (list == null) return;
			var listDb = uOW.ToDoListRepo.GetByID(list.Id);
			if (listDb == null) return;
			uOW.ToDoListRepo.Delete(listDb);
			uOW.Save();
		}
		/// <summary>
		/// Update list in db;
		/// </summary>
		/// <param name="list"></param>
		public void UpdateList(ToDoList list)
		{
			var ListDb = uOW.ToDoListRepo.GetByID(list.Id);
			if (ListDb == null) return;
			ListDb.Items = list.Items;
			ListDb.Name = list.Name;
			ListDb.Modified = DateTime.Now;
			uOW.Save();
		}
		/// <summary>
		/// Get by id list;
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ToDoList GetById(int id)
		{
			return uOW.ToDoListRepo.GetByID(id);
		}

	}
}
