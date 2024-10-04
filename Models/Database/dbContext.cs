using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
namespace Journals_System.Models.Database
{
    public class dbContext : DbContext
    {
        public DbSet<JournalsFiles> JournalsFiles { get; set; }
        public DbSet<Researchers> Researchers { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public dbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscriptions>()
        .HasOne(s => s.Subscriber)
        .WithMany() // Si no hay una colección de Subscriptions en Researchers
        .HasForeignKey(s => s.SubscriberId)
        .OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada

            modelBuilder.Entity<Subscriptions>()
                .HasOne(s => s.Followed)
                .WithMany() // Si no hay una colección de Followed en Researchers
                .HasForeignKey(s => s.FollowedId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
