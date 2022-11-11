using Godspeed.Domain.Models.Directory;
using Godspeed.Domain.Models.Manage;
using Godspeed.Domain.Models.UI;
using Godspeed.Infrastructure.Context.Interfaces;
using Godspeed.Infrastructure.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godspeed.Infrastructure.Context.Aspire
{
  public class AspireWebContext : DbContext, IContext
  {
    public AspireWebContext(AspireContextOptions options) : base(options.Value)
    {

    }

    public virtual DbSet<Person>? Person { get; set; }
    public virtual DbSet<Address>? Address { get; set; }
    public virtual DbSet<EntityApplication>? EntityApplication { get; set; }
    public virtual DbSet<EntityApplicationSettings>? EntityApplicationSettings { get; set; }
    public virtual DbSet<EntityApplicationUser>? EntityApplicationUser { get; set; }
    public virtual DbSet<Entity>? Entity { get; set; }
    public virtual DbSet<NavLinks>? NavLinks { get; set; }
    public virtual DbSet<Background>? Background { get; set; }
    public virtual DbSet<Forms>? Forms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Person>().HasKey(p => p.PersonID);
      modelBuilder.Entity<Entity>().HasKey(p => p.EntityID);
      modelBuilder.Entity<EntityApplicationSettings>().HasKey(e => e.EntityApplicationSettingID);
      modelBuilder.Entity<EntityApplicationUser>().HasKey(e => e.EntityApplicationUserID);
      modelBuilder.Entity<EntityApplication>();
      modelBuilder.Entity<Address>().HasKey(e => e.AddressID);
      modelBuilder.Entity<NavLinks>().HasKey(e => e.NavMenuID);
      modelBuilder.Entity<Background>().HasKey(e => e.BackgroundID);
      modelBuilder.Entity<Forms>().HasKey(e => e.FormID);





    }

  }
}
