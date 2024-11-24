using IrisTraining_Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace IrisTraining_Auth.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options) { 
        }
        public DbSet<User> Users { get; set; }
    }
}
