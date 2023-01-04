using Aspire.Common.Context;
using Godspeed.Infrastructure.Models;
using Microsoft.Extensions.Configuration;

namespace Godspeed.Infrastructure.Context.SecureGateContext
{
  public class SecureGateContextOptions : ContextOptions<SecureGateConfig>
  {
    public SecureGateContextOptions(IConfiguration configuration) : base(configuration)
    {
    }
  }
}
