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
		}

		public List<Tag> GetAll()
		{
			return uOW.TagRepo.All.ToList();
		}

		public Tag GetById(int id)
		{
			return uOW.TagRepo.GetByID(id);
		}

		public Tag Insert(Tag tag)
		{
			if (tag == null) return null;
			uOW.TagRepo.Insert(tag);
			uOW.Save();
			return tag;
		}

		public void RemoveTag(int id)
		{
			if (id == 0) return;
			var tagdb = uOW.TagRepo.GetByID(id);
			if (tagdb == null) return;
			uOW.TagRepo.Delete(tagdb);
			uOW.Save();
		}

		public void UpdateTag(Tag tag)
		{
			var tagDb = uOW.TagRepo.GetByID(tag.Id);
			if (tagDb == null) return;
			tagDb.Name = tag.Name;
			uOW.Save();
		}

		void ITagManager.AttachTag(Tag tag, int listId)
		{
			throw new NotImplementedException();
		}
	}
}
