using Mamba.Models;
using Microsoft.EntityFrameworkCore;

namespace Mamba.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
    }
}
