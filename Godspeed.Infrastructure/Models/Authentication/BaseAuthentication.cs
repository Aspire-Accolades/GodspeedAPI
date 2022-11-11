using Godspeed.Domain.Interfaces;
using Godspeed.Infrastructure.Models.Configurations;
using Godspeed.Infrastructure.Models.Configurations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godspeed.Infrastructure.Models.Authentication
{
  public class BaseAuthentication : IServerAuthConfig
  {
    [ConfigurationValue(ConfigKey = "WebSettings:Username")]
    public string Username { get; set; }

    [ConfigurationValue(ConfigKey = "WebSettings:Password")]
    public string Password { get; set; }
  }
}
