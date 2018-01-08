using System;
using Microsoft.EntityFrameworkCore;

namespace web.Models
{
    public class ServerContext : DbContext
    {
        public ServerContext(DbContextOptions<ServerContext> options) : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<FoodItem>().ToTable(("FoodItem"));
        }
        */
    }
}
