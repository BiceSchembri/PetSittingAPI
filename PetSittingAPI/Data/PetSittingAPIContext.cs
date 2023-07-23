using Microsoft.EntityFrameworkCore;
using PetSittingAPI.Models;

namespace PetSittingAPI.Data
{
    public class PetSittingAPIContext : DbContext
    {
        public PetSittingAPIContext(DbContextOptions<PetSittingAPIContext> options)
    : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Sitter> Sitters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and foreign keys

            // Pet to Category relationship
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Pets)
                .HasForeignKey(p => p.CategoryId);

            // Pet to Owner relationship
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.Pets)
                .HasForeignKey(p => p.OwnerId);

            // Pet to Sitter relationship (Nullable)
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Sitter)
                .WithMany(s => s.Pets)
                .HasForeignKey(p => p.SitterId)
                .OnDelete(DeleteBehavior.SetNull); // Optional: Set the behavior on delete to SetNull for the nullable foreign key
        }
    }
    }
