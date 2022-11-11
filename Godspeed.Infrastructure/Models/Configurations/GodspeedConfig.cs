using Godspeed.Domain.Interfaces;
using Godspeed.Infrastructure.Enums;
using Godspeed.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;

namespace Godspeed.Infrastructure.Models.Configurations
{
  public class GodspeedConfig : ISysConfig
  {
    [ConfigurationValue(ConfigKey = "Settings:Store")]
    public string Store { get; set; }
    [ConfigurationValue(ConfigKey = "Settings:Server")]
    public string Server { get; set; }
    [ConfigurationValue(ConfigKey = "Settings:Database")]
    public string Database { get; set; }

  }
}
