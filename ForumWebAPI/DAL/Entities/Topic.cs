using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual User Creator { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosureDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public virtual List<Message> Messages { get; set; }
        public virtual List<Complaint> Complaints { get; set; }
        public virtual List<User> Subscribers { get; set; }
        public bool IsClosed { get; set; }
        public bool IsDeleted { get; set; }
    }
}
