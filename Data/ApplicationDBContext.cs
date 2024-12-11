using Microsoft.EntityFrameworkCore;
using CombatGame.Models;
using System;

namespace CombatGame.Data
{
    public class ApplicationDbContext : DbContext
    {
#pragma warning disable CS8618
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Team1)
                .WithMany()
                .HasForeignKey(b => b.Team1Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Team2)
                .WithMany()
                .HasForeignKey(b => b.Team2Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "player1", Password = "password1" },
                new User { Id = 2, Username = "player2", Password = "password2" }
            );

            // Seed Teams
            modelBuilder.Entity<Team>().HasData(
                new Team { TeamId = 1, TeamName = "Warriors", UserId = 1 },
                new Team { TeamId = 2, TeamName = "Monsters", UserId = 2 }
            );

            // Seed Characters
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, Name = "Knight", Strength = 80, Defense = 70, Speed = 50, Intelligence = 60 },
                new Character { Id = 2, Name = "Archer", Strength = 60, Defense = 50, Speed = 90, Intelligence = 70 },
                new Character { Id = 3, Name = "Orc", Strength = 90, Defense = 80, Speed = 40, Intelligence = 30 },
                new Character { Id = 4, Name = "Goblin", Strength = 50, Defense = 40, Speed = 80, Intelligence = 60 }
            );

            // Seed Battles
            modelBuilder.Entity<Battle>().HasData(
                new Battle { Id = 1, Team1Id = 1, Team2Id = 2, Winner = "Warriors", BattleDate = DateTime.Now }
            );
        }
    }
}
