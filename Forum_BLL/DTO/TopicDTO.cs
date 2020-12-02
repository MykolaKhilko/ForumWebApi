using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_BLL.DTO
{
    public class TopicDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UserDTO Creator { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosureDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public List<MessageDTO> Messages { get; set; }
        public AdminDTO DeleteAdmin { get; set; }
        public List<ComplaintDTO> Complaints { get; set; }
        public List<UserDTO> Subscribers { get; set; }
        public bool IsClosed { get; set; }
        public bool isDeleted { get; set; }
    }
}
