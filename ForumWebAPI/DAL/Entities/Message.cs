using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public virtual User Author { get; set; }
        public string Text { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        //public virtual Message Reply { get; set; }
        //public virtual Message Answer { get; set; }
        public virtual List<Complaint> Complaints { get; set; }
    }
}
