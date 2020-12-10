using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void AddUser(UserDTO user);
        IQueryable<UserDTO> GetAll();
        UserDTO GetById(int id);
        IQueryable<TopicDTO> GetOwnTopics(int id);
        IQueryable<TopicDTO> GetSubscribedTopics(int id);
        IQueryable<ComplaintDTO> GetAllComplaints(int id);
        ComplaintDTO GetComplaintById(int idUser, int idComp);
        void AddComplaint(int id, string desc);
        void DeleteComplaint(int idUser, int idComp);
        void SubscribeTopic(int idUser, int idTopic);
        void UnsubscribeTopic(int idUser, int idTopic);
    }
}
