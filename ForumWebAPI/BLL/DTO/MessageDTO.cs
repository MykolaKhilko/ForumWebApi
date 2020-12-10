using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public virtual UserDTO Author { get; set; }
        public string Text { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<ComplaintDTO> Complaints { get; set; }
    }
}
