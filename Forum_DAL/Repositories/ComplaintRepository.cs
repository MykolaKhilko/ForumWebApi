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
    class ComplaintRepository : IRepository<Complaint>
    {
        readonly ForumDBContext db;
        public ComplaintRepository(ForumDBContext context)
        {
            db = context;
        }
        public async Task AddAsync(Complaint entity)
        {
            await db.Complaints.AddAsync(entity);
        }

        public void Delete(Complaint entity)
        {
            db.Complaints.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            db.Complaints.Remove(await db.Complaints.FindAsync(id));
        }

        public IQueryable<Complaint> GetAll()
        {
            return db.Complaints;
        }

        public IQueryable<Complaint> GetAllWithDetails()
        {
            return db.Complaints.Include(x => x.Author)
                .Include(x => x.UserComplaint)
                .Include(x => x.MessageComplaint)
                .Include(x => x.TopicComplaint);
        }

        public async Task<Complaint> GetByIdAsync(int id)
        {
            return await db.Complaints.FindAsync(id);
        }

        public async Task<Complaint> GetByIdWithDetails(int id)
        {
            return await db.Complaints.Include(x => x.Author)
                .Include(x => x.UserComplaint)
                .Include(x => x.MessageComplaint)
                .Include(x => x.TopicComplaint)
                .FirstOrDefaultAsync(x =>
                x.Id.ToString() == id.ToString());
        }

        public void Update(Complaint entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
