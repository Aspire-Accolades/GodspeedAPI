using Aspire.Common.Models.Configurations.Interfaces;
using Aspire.Common.Models.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godspeed.Infrastructure.Models
{
  public class GodspeedConfig : ISystemConfig
  {
    [ConfigurationValue(ConfigKey = "Settings:Store")]
    public string Store { get; set; }
    [ConfigurationValue(ConfigKey = "Settings:Server")]
    public string Server { get; set; }
    [ConfigurationValue(ConfigKey = "Settings:Database")]
    public string Database { get; set; }

  }
}
