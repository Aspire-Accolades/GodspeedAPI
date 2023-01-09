using Aspire.Common.Context;
using Godspeed.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godspeed.Infrastructure.Context.Aspire
{
  public class AspireContextOptions : ContextOptions<GodspeedConfig>
  {
    public AspireContextOptions(IConfiguration configuration) : base(configuration)
    {
      
    }
  }
}
