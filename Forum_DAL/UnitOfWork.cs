using Forum_DAL.Entities;
using Forum_DAL.Entities.Roles;
using Forum_DAL.Interfaces;
using Forum_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ForumDBContext db;
        UserRepository userRepository;
        AdminRepository adminRepository;
        ComplaintRepository complaintRepository;
        MessageRepository messageRepository;
        TopicRepository topicRepository;

        public UnitOfWork(ForumDBContext context)
        {
            db = context;
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }
                return userRepository;
            }
        }

        public IRepository<Admin> AdminRepository
        {
            get
            {
                if (adminRepository == null)
                {
                    adminRepository = new AdminRepository(db);
                }
                return adminRepository;
            }
        }
        public IRepository<Complaint> ComplaintRepository
        {
            get
            {
                if (complaintRepository == null)
                {
                    complaintRepository = new ComplaintRepository(db);
                }
                return complaintRepository;
            }
        }
        public IRepository<Message> MessageRepository
        {
            get
            {
                if (messageRepository == null)
                {
                    messageRepository = new MessageRepository(db);
                }
                return messageRepository;
            }
        }
        public IRepository<Topic> TopicRepository
        {
            get
            {
                if (topicRepository == null)
                {
                    topicRepository = new TopicRepository(db);
                }
                return topicRepository;
            }
        }
        public Task<int> SaveAsync()
        {
            return db.SaveChangesAsync();
        }
    }
}
