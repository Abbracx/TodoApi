using System;
using AutoMapper;
using TodoApi.Models;
using TodoApi.Models.Domain;

namespace TodoApi.Mappings
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<TodoItem, TodoItemDTO>().ReverseMap();
        }

        // Do this when the data are not same from the domain and DTO
        //public AutoMapperProfiles()
        //{
        //    CreateMap<UserDTO, UserDomain>().ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName)).ReverseMap();
        //}


    }
}


//public class UserDomain
//{
//    public string Name { get; set; } = null!;
//}


//public class UserDTO
//{
//    public string FullName { get; set; } = null!;
//}
