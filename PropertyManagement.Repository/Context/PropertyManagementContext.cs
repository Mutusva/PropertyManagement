using Microsoft.EntityFrameworkCore;
using PropertyManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyManagement.Repository.Context
{
  public class PropertyManagementContext : DbContext
  {

    public PropertyManagementContext(DbContextOptions<PropertyManagementContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //  optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PropertyManagement;Trusted_Connection=True;");
    //}

    public DbSet<PropertyDetail> PropertyDetail { get; set; }
    public DbSet<OwnerHistory> OwnerHistory { get; set; }
    public DbSet<PropertyImage> PropertyImage { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<PropertyDetail>().HasMany(s => s.PropertyImage).WithOne();
      //modelBuilder.Entity<PropertyDetail>()
      //  .HasMany<PropertyImage>()   
      //          .WithOne();


      modelBuilder.Entity<PropertyDetail>()
       .HasMany(x => x.OwnerHistory).WithOne();

      //modelBuilder.Entity<PropertyImage>();
     

      base.OnModelCreating(modelBuilder);
    }
  }
}
