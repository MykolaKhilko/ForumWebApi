using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ForumDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        public ForumDbContext(DbContextOptions options) :
            base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Topic>()
               .HasOne(p => p.Creator)
               .WithMany(p => p.MyTopics);

            modelBuilder.Entity<Topic>()
                .HasMany(p => p.Subscribers);

            modelBuilder.Entity<Complaint>()
                .HasOne(p => p.TopicComplaint)
                .WithMany(p => p.Complaints);

            modelBuilder.Entity<Complaint>()
                .HasOne(p => p.UserComplaint)
                .WithMany(p => p.Complaints);

            modelBuilder.Entity<Complaint>()
                .HasOne(p => p.MessageComplaint)
                .WithMany(p => p.Complaints);

            modelBuilder.Entity<Message>()
                .HasOne(p => p.Author)
                .WithMany();

            modelBuilder.Entity<Topic>()
                .HasMany(p => p.Messages)
                .WithOne();

            modelBuilder.ApplyConfigurationsFromAssembly(
                System.Reflection.Assembly.GetExecutingAssembly());

        }
    }
}
