using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using Forum_DAL.Entities.Roles;
using Forum_BLL.DTO;
using Forum_DAL.Entities;

namespace Forum_BLL
{
    class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Admin, AdminDTO>().ReverseMap();

            CreateMap <Complaint, ComplaintDTO>().ReverseMap();

            CreateMap<Message, MessageDTO>().ReverseMap();

            CreateMap<Topic, TopicDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

        }
    }
}
