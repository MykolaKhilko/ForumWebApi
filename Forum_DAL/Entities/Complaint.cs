using Forum_DAL.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_DAL.Entities
{
    public class Complaint
    {
        public Guid Id { get; set; }
        public User Author { get; set; }
        public bool IsClosed { get; set; }
        public bool IsChecked { get; set; }
        public string Description { get; set; }
        public User UserComplaint { get; set; }
        public Topic TopicComplaint { get; set; }
        public Message MessageComplaint { get; set; }
    }
}
