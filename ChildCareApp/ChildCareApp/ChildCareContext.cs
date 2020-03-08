using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCareApp
{
    public class ChildCareContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Activity> ChildActivity { get; set; }
        public ChildCareContext()
        {

        }
        public ChildCareContext(DbContextOptions<ChildCareContext> options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ChildCareApp;Integrated Security=True;Connect Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Persons");
                entity.HasKey(e => e.Id).HasName("PK_Id");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PersonType).IsRequired();
            });
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("ChildActivity");
                entity.HasKey(e => e.ActivityId).HasName("PK_ActivityId");
                entity.Property(e => e.ActivityId).ValueGeneratedOnAdd();
                entity.Property(e => e.ActivityType).IsRequired();
                entity.HasOne(e => e.Person).WithMany().HasForeignKey(e => e.Id);
            });
        }
    }
}
