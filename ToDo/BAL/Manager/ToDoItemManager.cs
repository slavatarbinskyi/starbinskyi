﻿using BAL.Interface;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DB;

namespace BAL.Manager
{
	public class ToDoItemManager : BaseManager,IToDoItemManager
	{
		public ToDoItemManager(IUnitOfWork uOW)	: base(uOW)
        {
		}
		/// <summary>
		/// Change Name value;
		/// </summary>
		/// <returns></returns>
		public void SetText(int id, string newText)
		{
			var item = uOW.ToDoItemRepo.GetByID(id);
			item.Text = newText;
			uOW.Save();
		}

		/// <summary>
		/// Change IsCompleted value;
		/// </summary>
		/// <returns></returns>
		public void ChangeIsCompletedValue(int id,bool newValue)
		{
			var item = uOW.ToDoItemRepo.GetByID(id);
			item.IsCompleted = newValue;
			uOW.Save();
		}
		/// <summary>
		/// Get all items from db.
		/// </summary>
		/// <returns></returns>
		public List<ToDoItem> GetAll()
		{
			return uOW.ToDoItemRepo.All.ToList();
		}
		/// <summary>
		/// Get All not completed items;
		/// </summary>
		/// <returns></returns>
		public List<ToDoItem> GetAllNotCompleted()
		{
			return uOW.ToDoItemRepo.All.Where(i=>i.IsCompleted==false).ToList();
		}

		/// <summary>
		/// Insert item into db;
		/// </summary>
		/// <param name="item"></param>
		public void InsertItem(ToDoItem item)
		{
			if (item == null) return;
			item.Created = DateTime.Now;
			uOW.ToDoItemRepo.Insert(item);
			uOW.Save();
		}
		/// <summary>
		/// Mark item as completed in db;
		/// </summary>
		/// <param name="Id"></param>
		public void MarkAsCompleted(int Id)
		{
			var ItemDb = uOW.ToDoItemRepo.GetByID(Id);
			if (ItemDb == null) return;
			ItemDb.IsCompleted = true;
			uOW.Save();
		}

		/// <summary>
		/// Remove item from db;
		/// </summary>
		/// <param name="item"></param>
		public void RemoveItem(ToDoItem item)
		{
			if (item == null) return;
			var itemDb = uOW.ToDoItemRepo.GetByID(item.Id);
			if (itemDb == null) return;
			uOW.ToDoListRepo.Delete(itemDb);
			uOW.Save();
		}
		/// <summary>
		/// Update item ;
		/// </summary>
		/// <param name="item"></param>
		public void UpdateItem(ToDoItem item)
		{
			var ItemDb = uOW.ToDoItemRepo.GetByID(item.Id);
			if (ItemDb == null) return;
			ItemDb.Text = item.Text;
			ItemDb.Priority = item.Priority;
			ItemDb.Modified = DateTime.Now;
			uOW.Save();
		}
		/// <summary>
		/// Get by id item;
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ToDoItem GetById(int id)
		{
			return uOW.ToDoItemRepo.GetByID(id);
		}
	}
}
