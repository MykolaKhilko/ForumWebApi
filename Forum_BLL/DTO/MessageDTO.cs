using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_BLL.DTO
{
    public class MessageDTO
    {
        public Guid Id { get; set; }
        public UserDTO Author { get; set; }
        public string Text { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public AdminDTO DeleteAdmin { get; set; }
        public MessageDTO Answer { get; set; }
        public List<ComplaintDTO> Complaints { get; set; }
    }
}
