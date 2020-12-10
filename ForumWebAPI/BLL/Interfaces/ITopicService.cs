using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    public interface ITopicService
    {
        IQueryable<TopicDTO> GetAll();
        TopicDTO GetById(int id);
        void Add(TopicDTO topic);
        void Delete(int id);
        void Update(TopicDTO topic);
        void AddComplaint(int id, string desc);
        void DeleteComplaint(int idTopic, int idComp);
        IQueryable<ComplaintDTO> GetAllComplaints(int idTopic);
        ComplaintDTO GetComplaintById(int idTopic, int idComp);
    }
}
