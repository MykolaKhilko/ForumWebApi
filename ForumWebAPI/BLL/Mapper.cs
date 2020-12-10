using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Complaint, ComplaintDTO>().ReverseMap();

            CreateMap<Message, MessageDTO>().ReverseMap();

            CreateMap<Topic, TopicDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

        }
    }
}
