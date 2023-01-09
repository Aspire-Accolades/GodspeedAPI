using Aspire.Common.Context.Interfaces;
using Godspeed.Domain.Models.Directory;
using Godspeed.Domain.Models.Manage;
using Godspeed.Domain.Models.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godspeed.Infrastructure.Context.SecureGateContext
{
  public class SecureGateContext : DbContext, IContext
  {
    public SecureGateContext(SecureGateContextOptions options) : base(options.Value)
    {

    }

    public virtual DbSet<Store>? Store { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Store>().HasKey(e => e.StoreID);
    }
  }
}
