using Forum_DAL.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_DAL.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public User Author { get; set; }
        public string Text { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public Admin DeleteAdmin { get; set; }
        public Message Answer { get; set; }
        public List<Complaint> Complaints { get; set; }
    }
}
