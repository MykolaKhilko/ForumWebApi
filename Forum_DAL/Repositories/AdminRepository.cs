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
    class AdminRepository : IRepository<Admin>
    {
        readonly ForumDBContext db;
        public AdminRepository(ForumDBContext context)
        {
            db = context;
        }
        public async Task AddAsync(Admin entity)
        {
            await db.Admins.AddAsync(entity);
        }

        public void Delete(Admin entity)
        {
            db.Admins.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            db.Admins.Remove(await db.Admins.FindAsync(id));
        }

        public IQueryable<Admin> GetAll()
        {
            return db.Admins;
        }

        public IQueryable<Admin> GetAllWithDetails()
        {
            return db.Admins.Include(x => x.DeletedTopics);
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
            return await db.Admins.FindAsync(id);
        }

        public async Task<Admin> GetByIdWithDetails(int id)
        {
            return await db.Admins.Include(x => x.DeletedTopics)
                .FirstOrDefaultAsync(x => 
                x.Id.ToString() == id.ToString());
        }

        public void Update(Admin entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
