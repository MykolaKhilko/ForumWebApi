using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_BLL.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<TopicDTO> MyTopics { get; set; }
        public List<TopicDTO> SubscribedTopics { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsBlocked { get; set; }
        public List<ComplaintDTO> Complaints { get; set; }
    }
}
