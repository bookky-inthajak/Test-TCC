using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }


}
