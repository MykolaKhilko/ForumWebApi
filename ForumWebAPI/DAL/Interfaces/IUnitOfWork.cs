using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Complaint> ComplaintRepository { get; }
        IRepository<Message> MessageRepository { get; }
        IRepository<Topic> TopicRepository { get; }
        Task<int> SaveAsync();
    }
}
