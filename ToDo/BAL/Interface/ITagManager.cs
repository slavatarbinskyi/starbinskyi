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
		void RemoveTag(int id);
		Tag GetById(int id);
	}
}
