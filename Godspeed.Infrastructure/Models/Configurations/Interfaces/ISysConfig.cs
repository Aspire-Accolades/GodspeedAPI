using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godspeed.Infrastructure.Models.Configurations;

namespace Godspeed.Domain.Interfaces
{
  public interface ISysConfig
  {
    [ConfigurationValue(ConfigKey = "Settings:Server")]
    public string Server { get; set; }

    [ConfigurationValue(ConfigKey = "Settings:Database")]
    public string Database { get; set; }
  }
}
