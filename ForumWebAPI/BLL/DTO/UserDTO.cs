using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<TopicDTO> MyTopics { get; set; }
        public virtual List<TopicDTO> SubscribedTopics { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsBlocked { get; set; }
        public virtual List<ComplaintDTO> Complaints { get; set; }
        public string RoleDTO { get; set; }
    }
}
