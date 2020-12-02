using Forum_DAL.Entities;
using Forum_DAL.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Admin> AdminRepository { get; }
        IRepository<Complaint> ComplaintRepository { get; }
        IRepository<Message> MessageRepository { get; }
        IRepository<Topic> TopicRepository { get; }
        Task<int> SaveAsync();
    }
}
