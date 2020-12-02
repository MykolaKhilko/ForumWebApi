using Forum_DAL.Entities.Roles;
using Forum_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_DAL
{
    public class ForumDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        public ForumDBContext(DbContextOptions<ForumDBContext> options) :
            base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("myrealconnectionstring");
        }
    }
}
