using Forum_DAL.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_DAL.Entities
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User Creator { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosureDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public List<Message> Messages { get; set; }
        public Admin DeleteAdmin { get; set; }
        public List<Complaint> Complaints { get; set; }
        public List<User> Subscribers { get; set; }
        public bool IsClosed { get; set; }
        public bool isDeleted { get; set; }
    }
}
