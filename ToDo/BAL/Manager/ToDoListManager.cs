using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BAL.Interface;
using DAL.Interface;
using Model.DB;
using Model.DTO;

namespace BAL.Manager
{
	public class ToDoListManager : BaseManager, IToDoListManager
	{
		public ToDoListManager(IUnitOfWork uOW) : base(uOW)
		{
		}

		/// <summary>
		///     Change Name value;
		/// </summary>
		/// <returns></returns>
		public void SetName(int id, string newName)
		{
			var item = uOW.ToDoListRepo.GetByID(id);
			item.Name = newName;
			uOW.Save();
		}

		/// <summary>
		///     Get all lists from db.
		/// </summary>
		/// <returns></returns>
		public List<ListTagsDTO> GetAll()
		{
			var result = new List<ListTagsDTO>();
			var toDoLists = uOW.ToDoListRepo.All.ToList();

			foreach (var list in toDoLists)
			{
				var listTag = Mapper.Map<ListTagsDTO>(list);

				//get ids of tags with list
				var ids = uOW.TagToDoListsRepo.All.Where(i => i.ToDoListId == list.Id).Select(i => i.TagId).ToList();
				//get tags with list
				var tags = uOW.TagRepo.All.Where(m => ids.Contains(m.Id)).ToList();
				var items = uOW.ToDoItemRepo.All.Where(i => i.ToDoList_Id == list.Id).OrderBy(o => o.IsCompleted).ToList();

				listTag.Items.AddRange(items);

				listTag.Tags.AddRange(tags);

				result.Add(listTag);
			}
			return result;
		}


		/// <summary>
		///     Insert list into db.
		/// </summary>
		/// <param name="list"></param>
		public ListTagsDTO InsertList(ToDoList list)
		{
			if (list == null) return null;
			uOW.ToDoListRepo.Insert(list);
			uOW.Save();
			var listmap = Mapper.Map<ListTagsDTO>(list);
			return listmap;
		}

		/// <summary>
		///     Remove list from db;
		/// </summary>
		/// <param name="list"></param>
		public void RemoveList(int id)
		{
			if (id == 0) return;
			var listDb = uOW.ToDoListRepo.GetByID(id);
			if (listDb == null) return;
			uOW.ToDoListRepo.Delete(listDb);
			uOW.Save();
		}

		/// <summary>
		///     Update list in db;
		/// </summary>
		/// <param name="list"></param>
		public void UpdateList(ToDoList list)
		{
			var ListDb = uOW.ToDoListRepo.GetByID(list.Id);
			if (ListDb == null) return;
			ListDb.Items = list.Items;
			ListDb.Name = list.Name;
			uOW.Save();
		}

		/// <summary>
		///     Get by id list;
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ToDoList GetById(int id)
		{
			return uOW.ToDoListRepo.GetByID(id);
		}

		public List<ListTagsDTO> GetListsByTagName(string Name)
		{
			var tagDb = uOW.TagRepo.All.FirstOrDefault(o => o.Name == Name).Id;
			var listsId = uOW.TagToDoListsRepo.All.Where(q => q.TagId == tagDb).Select(q => q.ToDoListId).ToList();
			var resultLists = new List<ListTagsDTO>();
			foreach (var listid in listsId)
			{
				var list = uOW.ToDoListRepo.Get(includeProperties: "Items").Where(i => i.Id == listid).FirstOrDefault();
				var listDTO = Mapper.Map<ListTagsDTO>(list);
				var ids = uOW.TagToDoListsRepo.All.Where(i => i.ToDoListId == list.Id).Select(i => i.TagId).ToList();
				var tags = uOW.TagRepo.All.Where(m => ids.Contains(m.Id)).ToList();
				listDTO.Tags.AddRange(tags);
				resultLists.Add(listDTO);
			}
			return resultLists;
		}
	}
}