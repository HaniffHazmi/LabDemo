using Microsoft.EntityFrameworkCore;
using LabDemo.Models;

namespace LabDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Chore> Chores { get; set; }
    }
}
