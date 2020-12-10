using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ComplaintDTO
    {
        public int Id { get; set; }
        public bool IsClosed { get; set; }
        public bool IsChecked { get; set; }
        public string Description { get; set; }
        public virtual UserDTO UserComplaint { get; set; }
        public virtual TopicDTO TopicComplaint { get; set; }
        public virtual MessageDTO MessageComplaint { get; set; }
    }
}
