using GodlessAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GodlessAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Godless> Gods { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Godless>()
            .Property(p => p.Creation)
            .HasDefaultValueSql("GETDATE()");

        // Seed data

        modelBuilder.Entity<Godless>().HasData(
            new Godless { Id = 1, Name = "Product A", Creation = DateTime.Now },
            new Godless { Id = 2, Name = "Thor", Creation = DateTime.Now },
            new Godless { Id = 3, Name = "Odin A", Creation = DateTime.Now },
            new Godless { Id = 4, Name = "Thanos A", Creation = DateTime.Now },
            new Godless { Id = 5, Name = "Julius A", Creation = DateTime.Now }
        );
    }

}
