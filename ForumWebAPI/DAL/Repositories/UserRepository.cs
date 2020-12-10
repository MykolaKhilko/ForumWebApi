using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        readonly ForumDbContext db;
        public UserRepository(ForumDbContext context)
        {
            db = context;
        }
        public async Task AddAsync(User entity)
        {
            await db.Users.AddAsync(entity);
        }

        public void Delete(User entity)
        {
            db.Users.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            db.Users.Remove(await db.Users.FindAsync(id));
        }

        public IQueryable<User> GetAll()
        {
            return db.Users;
        }

        public IQueryable<User> GetAllWithDetails()
        {
            return db.Users.Include(x => x.MyTopics)
                .Include(x => x.SubscribedTopics)
                .Include(x => x.Complaints);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await db.Users.FindAsync(id);
        }

        public async Task<User> GetByIdWithDetails(int id)
        {
            return await db.Users.Include(x => x.MyTopics)
                .Include(x => x.SubscribedTopics)
                .Include(x => x.Complaints)
                .FirstOrDefaultAsync(x =>
                x.Id.ToString() == id.ToString());
        }

        public void Update(User entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public Task<User> FindByNicknameAsync(string userName)
        {
            return Task<User>.Factory.StartNew(() =>
            db.Users.FirstOrDefault(u => u.Nickname == userName));
        }
    }
}
