using Forum_DAL.Entities;
using Forum_DAL.Entities.Roles;
using Forum_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Repositories
{
    class MessageRepository : IRepository<Message>
    {
        readonly ForumDBContext db;
        public MessageRepository(ForumDBContext context)
        {
            db = context;
        }
        public async Task AddAsync(Message entity)
        {
            await db.Messages.AddAsync(entity);
        }

        public void Delete(Message entity)
        {
            db.Messages.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            db.Messages.Remove(await db.Messages.FindAsync(id));
        }

        public IQueryable<Message> GetAll()
        {
            return db.Messages;
        }

        public IQueryable<Message> GetAllWithDetails()
        {
            return db.Messages.Include(x => x.Author)
                .Include(x => x.DeleteAdmin)
                .Include(x => x.Answer)
                .Include(x => x.Complaints);
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await db.Messages.FindAsync(id);
        }

        public async Task<Message> GetByIdWithDetails(int id)
        {
            return await db.Messages.Include(x => x.Author)
                .Include(x => x.DeleteAdmin)
                .Include(x => x.Answer)
                .Include(x => x.Complaints)
                .FirstOrDefaultAsync(x =>
                x.Id.ToString() == id.ToString());
        }

        public void Update(Message entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
