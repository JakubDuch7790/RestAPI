using GodlessAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GodlessAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Godless> Gods { get; set; }
    public DbSet<GodNumber> GodsNumbers { get; set; }


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

        modelBuilder.Entity<GodNumber>().HasData(
            new GodNumber { GodNo = 1,      SpecialDetails = "SuperVision",     CreationDate = DateTime.Now },
            new GodNumber { GodNo = 20,     SpecialDetails = "BigDick",         CreationDate = DateTime.Now },
            new GodNumber { GodNo = 333,    SpecialDetails = "SuperYoung",      CreationDate = DateTime.Now },
            new GodNumber { GodNo = 458,    SpecialDetails = "Tripple Nipple",  CreationDate = DateTime.Now },
            new GodNumber { GodNo = 566,    SpecialDetails = "TechKing",        CreationDate = DateTime.Now }
        );
    }

}
