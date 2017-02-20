using System.Collections.Generic;
using Model.DB;
using WebApp.Models;

namespace BAL.Interface
{
	public interface ITagManager
	{
		void AttachTag(Tag tag, int listId);
		Tag Insert(Tag tag);
		List<Tag> GetAll();
		void UpdateTag(Tag tag);
		void RemoveTag(string Name);
		Tag GetById(int id);
		void RemoveTagList(string Name, int listId);
		Tag GetByName(string Name);
		List<TopTagViewModel> GetTopTags();
	}
}