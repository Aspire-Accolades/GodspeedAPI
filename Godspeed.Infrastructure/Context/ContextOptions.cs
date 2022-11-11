using Godspeed.Domain.Interfaces;
using Godspeed.Infrastructure.Context.Aspire;
using Godspeed.Infrastructure.Context.Interfaces;
using Godspeed.Infrastructure.Helpers;
using Godspeed.Infrastructure.Models.Authentication;
using Godspeed.Infrastructure.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DbContext = System.Data.Entity.DbContext;

namespace Godspeed.Infrastructure.Context
{
  public abstract class ContextOptions<TConfiguration> : IContextOptions<TConfiguration>
    where TConfiguration : class, ISysConfig, new()
  {
    protected TConfiguration SystemConfig { get; set; }
    protected BaseAuthentication ServerAuthentication { get; set; }
    public string ConnectionString
    {
      get
      {
        return $"Data Source={SystemConfig.Server};Initial Catalog={SystemConfig.Database};User ID={ServerAuthentication.Username};Password={ServerAuthentication.Password}";
      }
    }

    public DbContextOptions Value
    {
      get
      {
        return new DbContextOptionsBuilder().UseSqlServer(ConnectionString).Options;

      }
    }
    public ContextOptions(IConfiguration configuration)
    {
      SystemConfig = ConfigurationHelper.Get<TConfiguration>(configuration);
      ServerAuthentication = ConfigurationHelper.GetAuth<BaseAuthentication>(configuration);
    }
  }
}