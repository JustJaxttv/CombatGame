using Microsoft.EntityFrameworkCore;
using CombatGame.Models;

namespace CombatGame.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Battle> Battles { get; set; }
    }
}
