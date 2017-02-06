using BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DB;
using DAL.Interface;

namespace BAL.Manager
{
	public class TagManager : BaseManager,ITagManager
	{
		public TagManager(IUnitOfWork uOW) : base(uOW)
		{
		}

		public void AttachTag(Tag tag, int listId)
		{
			var newtag = Insert(tag);
			var tagId = newtag.Id;
			var tagToDo = new TagToDoLists()
			{
				TagId = tagId,
				ToDoListId = listId
			};
			uOW.TagToDoListsRepo.Insert(tagToDo);
			uOW.Save();
		}

		public List<Tag> GetAll()
		{
			return uOW.TagRepo.All.ToList();
		}

		public Tag GetById(int id)
		{
			return uOW.TagRepo.GetByID(id);
		}
		public Tag GetByName(string Name)
		{
			return uOW.TagRepo.All.Where(i => i.Name == Name).FirstOrDefault();
		}

		public Tag Insert(Tag tag)
		{
			if (tag == null) return null;
			var tagDb = uOW.TagRepo.All.Where(i => i.Name == tag.Name).FirstOrDefault();
			if (tagDb!= null)
			{
				return tagDb;
			}
			else
			{
				uOW.TagRepo.Insert(tag);
				uOW.Save();
				return tag;
			}
		}

		public void RemoveTag(string Name)
		{
			if (Name == null) return;
			var tagdb = uOW.TagRepo.All.Where(i => i.Name == Name).FirstOrDefault();
			if (tagdb == null) return;
			uOW.TagRepo.Delete(tagdb);
			uOW.Save();
		}
		public void RemoveTagList(string Name,int listId)
		{
			if (Name == null) return;
			var tagId = GetByName(Name).Id;
			if (tagId == 0) return;
			var taglistdb = uOW.TagToDoListsRepo.All.Where(i => i.TagId == tagId && i.ToDoListId == listId).FirstOrDefault();
			if (taglistdb == null) return;
			uOW.TagToDoListsRepo.Delete(taglistdb);
			uOW.Save();
		}

		public void UpdateTag(Tag tag)
		{
			var tagDb = uOW.TagRepo.GetByID(tag.Id);
			if (tagDb == null) return;
			tagDb.Name = tag.Name;
			uOW.Save();
		}
	}
}
