using Aspire.Constants;
using Aspire.Security.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodspeedAPI
{
  public class Tools
  {
    private IConfigurationRoot? _config;
    public Tools()
    {
      _config = new ConfigurationBuilder()
     .AddJsonFile("appsettings.json", optional: false)
     .Build();
      setConfigs();
    }
    public string Server { get; set; } = string.Empty;
    public string? Database { get; set; } = string.Empty;
    public string Application { get; set; } = string.Empty;
    public string DBUser { get; set; } = string.Empty;
    public string DBPassword { get; set; } = string.Empty;
    public string ConnectionString
    {
      get
      {
        return $@"Data Source={Server};Initial Catalog={Database};User ID={DBUser};Password={DBPassword}";
      }
    }

    public DbContextOptions? _options
    {
      get
      {
        return new DbContextOptionsBuilder().UseSqlServer(ConnectionString).Options;
      }
    }

    public void setConfigs()
    {
      string server, database, application, username, password;
      IConfigurationSection? settingsSection = _config.GetSection(Keys.Settings);
      IConfigurationSection? webSettingsSection = _config.GetSection(Keys.WebSettings);
      Server = settingsSection.GetSection(Keys.Server).Value;
      DBPassword = webSettingsSection.GetSection(Keys.Password).Value;
      Application = settingsSection.GetSection(Keys.Application).Value;
      DBUser = webSettingsSection.GetSection(Keys.SysName).Value;

      if (!string.IsNullOrEmpty(settingsSection.GetSection(Keys.Database).Value))
      {
        Database = settingsSection.GetSection(Keys.Database).Value;
      }
      else
      {
        Database = SecretKeys.DefaultSystem;

      }
    }
  }
}
