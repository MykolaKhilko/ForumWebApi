using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Complaint
    {
        public int Id { get; set; }
        public bool IsClosed { get; set; }
        public bool IsChecked { get; set; }
        public string Description { get; set; }
        public virtual User UserComplaint { get; set; }
        public virtual Topic TopicComplaint { get; set; }
        public virtual Message MessageComplaint { get; set; }
    }
}
