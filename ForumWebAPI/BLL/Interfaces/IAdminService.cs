using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    public interface IAdminService
    {
        IQueryable<ComplaintDTO> GetAllComplaints();
        ComplaintDTO GetComplaintById(int id);
        void DiscardComplaint(int id);
        void AcceptComplaint(int id);
    }
}
