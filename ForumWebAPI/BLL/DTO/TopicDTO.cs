using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class TopicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual UserDTO Creator { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosureDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public virtual List<MessageDTO> Messages { get; set; }
        public virtual List<ComplaintDTO> Complaints { get; set; }
        public virtual List<UserDTO> Subscribers { get; set; }
        public bool IsClosed { get; set; }
        public bool IsDeleted { get; set; }
    }
}
