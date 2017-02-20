using System.Collections.Generic;
using System.Linq;
using BAL.Interface;
using DAL;
using DAL.Interface;
using Model.DB;
using WebApp.Models;

namespace BAL.Manager
{
	public class TagManager : BaseManager, ITagManager
	{
		public TagManager(IUnitOfWork uOW) : base(uOW)
		{
		}

		/// <summary>
		/// Get Top Tags;
		/// </summary>
		/// <returns></returns>
		public List<TopTagViewModel> GetTopTags()
		{
			using (
				var maincontext =
					new MainContext(
						@"Data Source=CH977\SQLEXPRESS;Initial Catalog=ToDo;Persist Security Info=True;User ID=vtarb;Password=qwerty"))
			{
				var result = new List<TopTagViewModel>();
				var tags =
					maincontext.Database.SqlQuery<TopTagViewModel>(
						@"SELECT TOP 10 TagToDoLists.TagId, COUNT(*) AS COUNTOF,Tags.Name FROM TagToDoLists
							INNER JOIN Tags 
							ON TagToDoLists.TagId = Tags.Id
							GROUP BY TagId, Tags.Name
							ORDER BY COUNT(*) DESC");
				result.AddRange(tags);
				return result;
			}
		}

		/// <summary>
		/// Attach tag to list
		/// </summary>
		/// <param name="tag"></param>
		/// <param name="listId"></param>
		public void AttachTag(Tag tag, int listId)
		{
			var newtag = Insert(tag);
			var tagId = newtag.Id;
			var tagToDo = new TagToDoLists
			{
				TagId = tagId,
				ToDoListId = listId
			};
			var taglist = uOW.TagToDoListsRepo.All.FirstOrDefault(i => i.TagId == tagId && i.ToDoListId == listId);
			if (taglist == null)
			{
				uOW.TagToDoListsRepo.Insert(tagToDo);
				uOW.Save();
			}
		}
		/// <summary>
		/// Get all tags;
		/// </summary>
		/// <returns></returns>
		public List<Tag> GetAll()
		{
			return uOW.TagRepo.All.ToList();
		}
		/// <summary>
		/// Get tag by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Tag GetById(int id)
		{
			return uOW.TagRepo.GetByID(id);
		}
		/// <summary>
		/// Get tag by name
		/// </summary>
		/// <param name="Name"></param>
		/// <returns></returns>
		public Tag GetByName(string Name)
		{
			return uOW.TagRepo.All.FirstOrDefault(i => i.Name == Name);
		}
		/// <summary>
		/// Insert tag in db
		/// </summary>
		/// <param name="tag"></param>
		/// <returns></returns>
		public Tag Insert(Tag tag)
		{
			if (tag == null) return null;
			var tagDb = uOW.TagRepo.All.FirstOrDefault(i => i.Name == tag.Name);
			if (tagDb != null)
			{
				return tagDb;
			}
			uOW.TagRepo.Insert(tag);
			uOW.Save();
			return tag;
		}
		/// <summary>
		/// Remove tag
		/// </summary>
		/// <param name="Name"></param>
		public void RemoveTag(string Name)
		{
			if (Name == null) return;
			var tagdb = uOW.TagRepo.All.FirstOrDefault(i => i.Name == Name);
			if (tagdb == null) return;
			uOW.TagRepo.Delete(tagdb);
			uOW.Save();
		}
		/// <summary>
		/// Remove tag 
		/// </summary>
		/// <param name="Name"></param>
		/// <param name="listId"></param>
		public void RemoveTagList(string Name, int listId)
		{
			if (Name == null) return;
			var tagId = GetByName(Name).Id;
			if (tagId == 0) return;
			var taglistdb = uOW.TagToDoListsRepo.All.FirstOrDefault(i => i.TagId == tagId && i.ToDoListId == listId);
			if (taglistdb == null) return;
			uOW.TagToDoListsRepo.Delete(taglistdb);
			uOW.Save();
		}
		/// <summary>
		/// Update tag
		/// </summary>
		/// <param name="tag"></param>
		public void UpdateTag(Tag tag)
		{
			var tagDb = uOW.TagRepo.GetByID(tag.Id);
			if (tagDb == null) return;
			tagDb.Name = tag.Name;
			uOW.Save();
		}
	}
}