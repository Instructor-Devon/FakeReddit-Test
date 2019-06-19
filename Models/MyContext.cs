using Microsoft.EntityFrameworkCore;

namespace EFFunzies.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users {get;set;}
        public DbSet<Message> Messages {get;set;}
        public DbSet<Vote> Votes {get;set;}
    }
}