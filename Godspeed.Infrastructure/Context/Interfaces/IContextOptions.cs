using Godspeed.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godspeed.Infrastructure.Context.Interfaces
{
  public interface IContextOptions<TConfiguration>
    where TConfiguration : class, ISysConfig, new ()
  {

  }
}
