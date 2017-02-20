using AutoMapper;
using Model.DB;
using Model.DTO;

namespace BAL
{
	public class MappingProfile : Profile
	{
		protected override void Configure()
		{
			base.Configure();
			CreateMap<ToDoList, ListTagsDTO>();
			CreateMap<ListTagsDTO, ToDoList>();
		}
	}
}