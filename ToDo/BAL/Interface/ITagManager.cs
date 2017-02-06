using Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
	public interface ITagManager
	{
		void AttachTag(Tag tag,int listId);
		Tag Insert(Tag tag);
		List<Tag> GetAll();
		void UpdateTag(Tag tag);
		void RemoveTag(string Name);
		Tag GetById(int id);
		void RemoveTagList(string Name, int listId);
		Tag GetByName(string Name);
	}
}
