using Aspire.Common.Models.Configurations.Interfaces;
using Aspire.Common.Models.Configurations;

namespace Godspeed.Infrastructure.Models
{
  public class SecureGateConfig : ISysConfig
  {
    [ConfigurationValue(ConfigKey = "SecureGate:Server")]
    public string Server { get; set; }
    [ConfigurationValue(ConfigKey = "SecureGate:Database")]
    public string Database { get; set; }

  }
}
