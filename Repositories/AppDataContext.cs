using Microsoft.EntityFrameworkCore;
using Liberry_v2.Models.Entities;

namespace Liberry_v2.Repositories
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books {get; set;}
        public DbSet<Loan> Loans {get; set;}
        public DbSet<Review> Reviews {get; set;}
        public DbSet<User> Users {get; set;}
        
    }
}