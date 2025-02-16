using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Metrics;
using Aspekt.Domain.Entities;

namespace Aspekt.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasKey(c => c.CompanyId);

            modelBuilder.Entity<Company>()
                .Property(c => c.CompanyName)
            .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Country>()
                .HasKey(c => c.CountryId);

            modelBuilder.Entity<Country>()
                .Property(c => c.CountryName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Contact>()
                .HasKey(c => c.ContactId);

            modelBuilder.Entity<Contact>()
                .Property(c => c.ContactName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
