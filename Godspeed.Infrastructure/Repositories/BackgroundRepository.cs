using Godspeed.Domain.Models.UI;
using Godspeed.Infrastructure.Context.Aspire;
using Godspeed.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godspeed.Infrastructure.Repositories
{
  public class BackgroundRepository : GenericRepository<Background, AspireWebContext>
  {
    public BackgroundRepository(AspireWebContext ctx) : base(ctx)
    {

    }


  }
}
