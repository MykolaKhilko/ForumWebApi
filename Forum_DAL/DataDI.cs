using Forum_DAL.Entities;
using Forum_DAL.Entities.Roles;
using Forum_DAL.Interfaces;
using Forum_DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL
{
    public static class DataDI
    {
        private const string DBConnectionString =
            nameof(DBConnectionString);
        public static void RegisterLibraryDAL(
            this IServiceCollection collection, 
            IConfiguration configuration)
        {
            var connection = configuration
                .GetConnectionString(DBConnectionString);
            collection.AddDbContextPool<ForumDBContext>(option => 
                option.UseSqlServer(connection));

            collection.AddScoped<IRepository<Admin>, 
                AdminRepository>();
            collection.AddScoped<IRepository<Complaint>, 
                ComplaintRepository>();
            collection.AddScoped<IRepository<Message>, 
                MessageRepository>();
            collection.AddScoped<IRepository<Topic>,
                TopicRepository>();
            collection.AddScoped<IRepository<User>, 
                UserRepository>();
            collection.AddScoped<IUnitOfWork, 
                UnitOfWork>();

        }
    }
}
