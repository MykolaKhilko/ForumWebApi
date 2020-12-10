using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    public interface IMessageService
    {
        IQueryable<MessageDTO> GetAllByTopic(int idTopic);
        MessageDTO GetByIdByTopic(int idTopic, int idMess);
        void AddToTopic(int idTopic, MessageDTO message);
        void DeleteFromTopic(int idTopic, int idMess);
        void Update(int idTopic, int idMess);
        void AddComplaint(int idTopic, int idMess, string desc);
        void DeleteComplaint(int idTopic, int idMess, int idComp);
        IQueryable<ComplaintDTO> GetAllComplaints(int idTopic,
            int idMess);
        ComplaintDTO GetComplaintById(int idTopic, int idMess,
            int idComp);
    }
}
