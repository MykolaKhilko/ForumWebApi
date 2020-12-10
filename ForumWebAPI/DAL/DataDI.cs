using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace DAL
{
    public static class DataDI
    {
        private const string DBConnectionString =
            nameof(DBConnectionString);
        public static void RegisterLibraryDAL(
            this IServiceCollection collection, 
            IConfiguration configuration)
        {
            //var connection = configuration
            //    .GetConnectionString(DBConnectionString);
            //collection.AddDbContextPool<ForumDbContext>(option =>
            //    option.UseSqlServer(connection));
           

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
