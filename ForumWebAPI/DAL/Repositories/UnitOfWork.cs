using DAL.Entities;
using DAL.Interfaces;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ForumDbContext db;
        UserRepository userRepository;
        ComplaintRepository complaintRepository;
        MessageRepository messageRepository;
        TopicRepository topicRepository;


        public UnitOfWork(ForumDbContext context)
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
