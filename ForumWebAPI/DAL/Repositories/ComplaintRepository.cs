using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ComplaintRepository : IRepository<Complaint>
    {
        readonly ForumDbContext db;
        public ComplaintRepository(ForumDbContext context)
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
            return db.Complaints.Include(x => x.UserComplaint)
                .Include(x => x.MessageComplaint)
                .Include(x => x.TopicComplaint);
        }

        public async Task<Complaint> GetByIdAsync(int id)
        {
            return await db.Complaints.FindAsync(id);
        }

        public async Task<Complaint> GetByIdWithDetails(int id)
        {
            return await db.Complaints.Include(x => x.UserComplaint)
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
