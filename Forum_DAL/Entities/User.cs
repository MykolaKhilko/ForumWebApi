using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_DAL.Entities.Roles
{
    public class User
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Topic> MyTopics { get; set; }
        public List<Topic> SubscribedTopics { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsBlocked { get; set; }
        public List<Complaint> Complaints { get; set; }
    }
}
