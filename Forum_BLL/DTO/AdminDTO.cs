using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_BLL.DTO
{
    public class AdminDTO
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<TopicDTO> DeletedTopics { get; set; }
    }
}
