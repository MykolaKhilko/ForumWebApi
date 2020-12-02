using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_BLL.DTO
{
    public class ComplaintDTO
    {
        public Guid Id { get; set; }
        public UserDTO Author { get; set; }
        public bool IsClosed { get; set; }
        public bool IsChecked { get; set; }
        public string Description { get; set; }
        public UserDTO UserComplaint { get; set; }
        public TopicDTO TopicComplaint { get; set; }
        public MessageDTO MessageComplaint { get; set; }
    }
}
