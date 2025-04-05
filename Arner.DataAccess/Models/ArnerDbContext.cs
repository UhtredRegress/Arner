using Arner.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.DataAccess
{
    public class ArnerDbContext:DbContext
    {
        public ArnerDbContext(DbContextOptions<ArnerDbContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<Models.Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(e => e.Username)
                .IsUnique();
            modelBuilder.Entity<Item>()
                .HasMany(e => e.Types)
                .WithMany(e => e.Items)
                .UsingEntity<ItemType>();
        }
    }
}
