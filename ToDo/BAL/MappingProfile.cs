using AutoMapper;
using Model.DB;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
	public class MappingProfile : Profile
	{
		protected override void Configure()
		{
			base.Configure();
			CreateMap<ToDoList,ListTagsDTO>();
			CreateMap<ListTagsDTO,ToDoList>();


		}
	}
}
