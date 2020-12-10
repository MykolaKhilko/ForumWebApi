using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TopicRepository : IRepository<Topic>
    {
        readonly ForumDbContext db;
        public TopicRepository(ForumDbContext context)
        {
            db = context;
        }
        public async Task AddAsync(Topic entity)
        {
            await db.Topics.AddAsync(entity);
        }

        public void Delete(Topic entity)
        {
            db.Topics.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            db.Topics.Remove(await db.Topics.FindAsync(id));
        }

        public IQueryable<Topic> GetAll()
        {
            return db.Topics;
        }

        public IQueryable<Topic> GetAllWithDetails()
        {
            return db.Topics.Include(x => x.Creator)
                .Include(x => x.Messages)
                .Include(x => x.Complaints)
                .Include(x => x.Subscribers);
        }

        public async Task<Topic> GetByIdAsync(int id)
        {
            return await db.Topics.FindAsync(id);
        }

        public async Task<Topic> GetByIdWithDetails(int id)
        {
            return await db.Topics.Include(x => x.Creator)
                .Include(x => x.Messages)
                .Include(x => x.Complaints)
                .Include(x => x.Subscribers)
                .FirstOrDefaultAsync(x =>
                x.Id.ToString() == id.ToString());
        }

        public void Update(Topic entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
