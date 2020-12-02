using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_DAL.Entities.Roles
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Topic> DeletedTopics { get; set; }
    }
}
